using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;

namespace ExaminationSystem.VerticalSlicing.Features.Quizzes.CreateQuiz.Commands
{
    public class CreateQuizCommand() : IRequest<ResultDTO>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateOfQuiz { get; set; }
    }

    public class CreateQuizCommandHandler : BaseRequestHandler<Quiz, CreateQuizCommand, ResultDTO>
    {
        public CreateQuizCommandHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            bool CheckQuitName = await _repository.GetAnyAsync(q => q.Deleted == false && q.Name == request.Name);

            if (CheckQuitName)
            {
                return ResultDTO.Failure("Quit Name already exists!");
            }

            var quiz = request.MapOne<Quiz>();
           
            
            _repository.CreateAsync(quiz);

            return ResultDTO.Success(true, "Create Quiz successfully!");
        }
    }
}
