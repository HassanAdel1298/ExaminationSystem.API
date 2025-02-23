using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes.Queries;
using Microsoft.AspNetCore.Authorization;
using ExaminationSystem.API.VerticalSlicing.Features.Questions.ShowQuestions.Queries;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.ShowQuestions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShowQuizDetailsController : BaseController
    {
        public ShowQuizDetailsController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<ResultDTO> ShowQuizDetails(int quizId)
        {
            var result = await _mediator.Send(new ShowQuizDetailsQuery(quizId));

            return result;
        }
    }
}
