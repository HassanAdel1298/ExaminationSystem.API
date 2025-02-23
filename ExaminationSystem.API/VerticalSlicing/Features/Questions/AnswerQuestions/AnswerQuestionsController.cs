using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystem.VerticalSlicing.Features.Questions.AnswerQuestions.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.AnswerQuestions
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerQuestionsController : BaseController
    {
        public AnswerQuestionsController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> AnswerQuestions(AnswerQuestionsCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
