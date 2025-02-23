using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using MediatR;

namespace ExaminationSystem.API.VerticalSlicing.Features.Quizzes.CheckQuitExist
{
    public record CheckQuitExistCommand(int QuizID) : IRequest<ResultDTO>;
    

    
    public class CheckQuitExistCommandHandler : BaseRequestHandler<Quiz, CheckQuitExistCommand, ResultDTO>
    {
        public CheckQuitExistCommandHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(CheckQuitExistCommand request, CancellationToken cancellationToken)
        {
            bool CheckQuitExist = await _repository.GetAnyAsync(q => q.Deleted == false && q.Id == request.QuizID);

            if (!CheckQuitExist)
            {
                return ResultDTO.Failure("Quit is not exists!");
            }

            return ResultDTO.Success(true, "Quit is exists");
        }
    }
}
