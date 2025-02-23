using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystem.VerticalSlicing.Features.Quizzes.UpdateQuiz.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.UpdateQuiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class UpdateQuizController : BaseController
    {
        public UpdateQuizController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> UpdateQuiz(UpdateQuizCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
