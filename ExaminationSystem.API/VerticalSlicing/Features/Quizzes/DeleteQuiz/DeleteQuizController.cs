using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystem.VerticalSlicing.Features.Quizzes.DeleteQuiz.Commands;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.DeleteQuiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeleteQuizController : BaseController
    {
        public DeleteQuizController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        public async Task<ResultDTO> DeleteQuiz(DeleteQuizCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
