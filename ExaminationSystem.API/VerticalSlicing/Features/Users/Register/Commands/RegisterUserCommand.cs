using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Users.Register;

namespace ExaminationSystem.VerticalSlicing.Features.Users.Register.Commands
{
    public class RegisterUserCommand() : IRequest<ResultDTO>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string Country { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public class RegisterUserCommandHandler : BaseRequestHandler<User, RegisterUserCommand, ResultDTO>
    {
        public RegisterUserCommandHandler(RequestParameters<User> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var emailAddress = await _repository.FirstOrDefaultAsync(u => u.Deleted == false && u.EmailAddress == request.EmailAddress);

            if (emailAddress is not null)
            {
                return ResultDTO.Failure("Email Address already exists!");
            }

            var userName = await _repository.FirstOrDefaultAsync(user => user.Deleted == false && user.UserName == request.UserName);

            if (userName is not null)
            {
                return ResultDTO.Failure("Username already exists!");
            }

            var user = request.MapOne<User>();
            user.Password = PasswordHelper.CreatePasswordHash(request.Password);
            user.OTP = OTPGenerator.CreateOTP();
            _repository.CreateAsync(user);

            EmailSenderDTO emailSenderDTO = new EmailSenderDTO()
            {
                ToEmail = user.EmailAddress,
                Subject = "Verify your email",
                Body = $"Please verify your email address by OTP : {user.OTP}"
            };

            EmailSender.SendEmail(emailSenderDTO);

            var mappedUser = user.MapOne<UserRegisterDTO>();
            return ResultDTO.Success(mappedUser, "User has been registered successfully!");
        }
    }
}
