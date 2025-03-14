using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.VerticalSlicing.Features.Users.Register;
using ExaminationSystem.VerticalSlicing.Features.Users.Register.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.Register
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : BaseController
    {
        public RegisterController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> Register(UserRegisterRequest user)
        {
            var result = await _mediator.Send(user.MapOne<RegisterUserCommand>());

            return result;
        }

    }
}
