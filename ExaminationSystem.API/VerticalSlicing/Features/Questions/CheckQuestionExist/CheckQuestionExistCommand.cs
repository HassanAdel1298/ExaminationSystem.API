using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using MediatR;

namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.CheckQuestionExist
{
    public record CheckQuestionExistCommand(int QuestionID) : IRequest<ResultDTO>;



    public class CheckQuestionExistCommandHandler : BaseRequestHandler<Question, CheckQuestionExistCommand, ResultDTO>
    {
        public CheckQuestionExistCommandHandler(RequestParameters<Question> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(CheckQuestionExistCommand request, CancellationToken cancellationToken)
        {
            bool CheckQuestionExist = await _repository.GetAnyAsync(q => q.Deleted == false && q.Id == request.QuestionID);

            if (!CheckQuestionExist)
            {
                return ResultDTO.Failure("Question is not exists!");
            }

            return ResultDTO.Success(true, "Question is exists");
        }
    }
}
