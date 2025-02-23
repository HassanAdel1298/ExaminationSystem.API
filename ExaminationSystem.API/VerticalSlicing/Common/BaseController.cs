using MediatR;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common.Constants;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;

namespace ExaminationSystem.API.VerticalSlicing.Common
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected readonly IMediator _mediator;
        protected readonly UserState _userState;
        public BaseController(ControllereParameters controllereParameters)
        {
            _mediator = controllereParameters.Mediator;
            _userState = controllereParameters.UserState;

            var loggedUser = new HttpContextAccessor().HttpContext.User;


            _userState.Id = loggedUser?.FindFirst(CustomClaimTypes.Id)?.Value ?? "";
            _userState.Email = loggedUser?.FindFirst(CustomClaimTypes.Email)?.Value ?? "";
            _userState.UserName = loggedUser?.FindFirst(CustomClaimTypes.UserName)?.Value ?? "";
        }
    }
}
