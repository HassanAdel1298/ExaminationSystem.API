using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.VerticalSlicing.Features.Users.Login.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.Login
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : BaseController
    {
        public LoginController(ControllereParameters controllereParameters) 
                            : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Login(UserLoginRequest user)
        {

            var result = await _mediator.Send(user.MapOne<LoginUserCommand>());

            return result;
        }
    }
}
