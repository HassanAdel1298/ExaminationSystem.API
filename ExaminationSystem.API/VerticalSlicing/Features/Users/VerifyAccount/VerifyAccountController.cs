using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount
{
    [Route("api/[controller]")]
    [ApiController]
    public class VerifyAccountController : BaseController
    {

        public VerifyAccountController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> VerifyAccount(VerifyAccountRequest verifyAccountRequest)
        {

            var resultDTO = await _mediator.Send(verifyAccountRequest.MapOne<VerifyAccountCommand>());

            return resultDTO;
        }
    }
}
