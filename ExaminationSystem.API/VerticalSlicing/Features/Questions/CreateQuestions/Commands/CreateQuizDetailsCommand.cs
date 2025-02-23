using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Quizzes.CheckQuitExist;

namespace ExaminationSystem.VerticalSlicing.Features.Questions.CreateQuestions.Commands
{
    public class CreateQuizDetailsCommand() : IRequest<ResultDTO>
    {
        public int QuizID { get; set; }
        public List<CreateQuestions> Questions { get; set; }
    }

    public class CreateQuestions()
    {
        public string Text { get; set; }
        public int Type { get; set; }
        public List<CreateChoises> Choises { get; set; }
    }

    public class CreateChoises()
    {
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }

    public class CreateQuizDetailsCommandHandler : BaseRequestHandler<Question, CreateQuizDetailsCommand, ResultDTO>
    {
        public CreateQuizDetailsCommandHandler(RequestParameters<Question> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(CreateQuizDetailsCommand request, CancellationToken cancellationToken)
        {
            var CheckQuitExist = await _mediator.Send(new CheckQuitExistCommand(request.QuizID));

            if (!CheckQuitExist.IsSuccess)
            {
                return ResultDTO.Failure("Quit is not exists!");
            }

            List<Question> questions = new List<Question>();

            foreach (var questionDto in request.Questions)
            {
                Question question = new Question()
                {
                    QuizID = request.QuizID,
                    Text = questionDto.Text,
                    Type = questionDto.Type,
                    Deleted = false
                };


                foreach (var choiseDto in question.Choises)
                {
                    Choise choise = new Choise()
                    {
                        Text = choiseDto.Text,
                        IsCorrect = choiseDto.IsCorrect,
                        Deleted = false
                    };
                    question.Choises.Add(choise);
                }
                questions.Add(question);
            }

            
            _repository.CreateListAsync(questions);

            return ResultDTO.Success(true, "Create Quiz Details successfully!");
        }
    }
}
