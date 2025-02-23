using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.VerticalSlicing.Features.Quizzes.DeleteQuiz.Commands
{
    public record DeleteQuizCommand(int Id) : IRequest<ResultDTO>;
    

    public class DeleteQuizCommandHandler : BaseRequestHandler<Quiz, DeleteQuizCommand, ResultDTO>
    {
        public DeleteQuizCommandHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {


            var quiz = await _repository.FirstOrDefaultAsync(q => q.Deleted == false && q.Id == request.Id);
            if (quiz == null)
            {
                return ResultDTO.Failure("Quit is not exists!");
            }

            quiz.Deleted = true;

            _repository.Update(quiz);
            await _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Create Quiz successfully!");
        }
    }
}
