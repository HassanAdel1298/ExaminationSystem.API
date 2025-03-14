using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount.Commands
{
    public record VerifyAccountCommand(string EmailAddress, string OTP) : IRequest<ResultDTO>;
    

    public class VerifyAccountCommandHandler : BaseRequestHandler<User, VerifyAccountCommand, ResultDTO>
    {

        public VerifyAccountCommandHandler(RequestParameters<User> requestParameters) : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(u => u.EmailAddress == request.EmailAddress &&
                                            u.OTP == request.OTP &&
                                            !u.IsEmailVerified);


            if (user is null)
            {
                return ResultDTO.Failure("Email or OTP is incorrect");
            }

            user.IsEmailVerified = true;

            _repository.Update(user);

            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Verify Account Successfully!");
        }

    }
}
