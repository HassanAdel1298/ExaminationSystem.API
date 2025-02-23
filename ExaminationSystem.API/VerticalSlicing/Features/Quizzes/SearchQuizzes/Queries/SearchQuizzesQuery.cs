using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using MediatR;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.SearchQuizzes.Queries
{
    public class SearchQuizzesQuery() : IRequest<ResultDTO> 
    {
        public string Name { get; set; }
    }
    public class SearchQuizzesQueryHandler : BaseRequestHandler<Quiz, SearchQuizzesQuery, ResultDTO>
    {
        public SearchQuizzesQueryHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(SearchQuizzesQuery request, CancellationToken cancellationToken)
        {

            var Quizzes = await _repository.GetWhereAsync(q => q.Deleted == false && q.Name == request.Name);

            if (Quizzes.ToList()?.Count <= default(int))
                return ResultDTO.Failure("No Data Found");

            return ResultDTO.Success(Quizzes.Map<SearchQuizzesDTO>(), "Get All Quizzes successfully!");
        }
    }
}
