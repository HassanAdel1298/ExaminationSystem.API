using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.VerticalSlicing.Features.Users.Register;
using ExaminationSystem.VerticalSlicing.Features.Users.Register.Commands;
using ExaminationSystem.VerticalSlicing.Features.Quizzes.CreateQuiz.Commands;
using Microsoft.AspNetCore.Authorization;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.CreateQuiz
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreateQuizController : BaseController
    {
        public CreateQuizController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> CreateQuiz(CreateQuizCommand request)
        {
            var result = await _mediator.Send(request);

            return result;
        }

    }
}
