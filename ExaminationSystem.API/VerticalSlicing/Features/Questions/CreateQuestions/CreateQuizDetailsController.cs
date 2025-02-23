using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.VerticalSlicing.Features.Questions.CreateQuestions.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.CreateQuestions
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuizDetailsController : BaseController
    {
        public CreateQuizDetailsController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> CreateQuizDetails(CreateQuizDetailsCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
