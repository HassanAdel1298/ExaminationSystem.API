using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Features.Users.GetUserById.Queries;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.GetUserById
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetUserByIdController : BaseController
    {
        public GetUserByIdController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpGet]
        public async Task<ResultDTO> GetUserById(int id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(id));

            return result;
        }
    }
}
