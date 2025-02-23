using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using Microsoft.AspNetCore.Mvc;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes.Queries;
using Microsoft.AspNetCore.Authorization;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchQuizzesController : BaseController
    {
        public SearchQuizzesController(ControllereParameters controllereParameters) : base(controllereParameters)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<ResultDTO> SearchQuizzes(SearchQuizzesQuery request)
        {
            var result = await _mediator.Send(request);

            return result;
        }
    }
}
