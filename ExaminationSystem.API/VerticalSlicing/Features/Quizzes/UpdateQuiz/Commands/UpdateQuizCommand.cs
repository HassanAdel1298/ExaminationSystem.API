using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.VerticalSlicing.Features.Quizzes.UpdateQuiz.Commands
{
    public class UpdateQuizCommand() : IRequest<ResultDTO>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateOfQuiz { get; set; }
    }

    public class UpdateQuizCommandHandler : BaseRequestHandler<Quiz, UpdateQuizCommand, ResultDTO>
    {
        public UpdateQuizCommandHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
        {

            bool CheckQuitName = await _repository.GetAnyAsync(q => q.Deleted == false && q.Name == request.Name && q.Id != request.Id);

            if (CheckQuitName)
            {
                return ResultDTO.Failure("Quit Name already exists!");
            }
            var quiz = await _repository.FirstOrDefaultAsync(q => q.Deleted == false && q.Id == request.Id);
            if (quiz == null)
            {
                return ResultDTO.Failure("Quit is not exists!");
            }

            quiz.Name = request.Name;
            quiz.Description = request.Description;
            quiz.Image = request.Image;
            quiz.DateOfQuiz = request.DateOfQuiz;
            
            
            _repository.Update(quiz);
            _repository.SaveChangesAsync();

            return ResultDTO.Success(true, "Update Quiz successfully!");
        }
    }
}
