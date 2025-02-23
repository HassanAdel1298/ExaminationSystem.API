using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.VerticalSlicing.Features.Users.Login.Commands
{
    public record LoginUserCommand(string EmailAddress, string Password) : IRequest<ResultDTO>;
    

    public class LoginUserCommandHandler : BaseRequestHandler<User, LoginUserCommand, ResultDTO>
    {
        public LoginUserCommandHandler(RequestParameters<User> requestParameters) 
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.FirstOrDefaultAsync(u => u.EmailAddress == request.EmailAddress
                                                    && u.IsEmailVerified);

            if (user is null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return ResultDTO.Failure("Email or Password is incorrect");
            }

            var userDTO = user.MapOne<UserForTokenDTO>();
            var token = TokenGenerator.GenerateToken(userDTO);

            return ResultDTO.Success(token, "User is logged in!");
        }
    }
}
