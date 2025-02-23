using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using MediatR;

namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.ShowQuestions.Queries
{
    public record ShowQuizDetailsQuery(int quizId) : IRequest<ResultDTO>;
    
    public class ShowQuizDetailsQueryHandler : BaseRequestHandler<Quiz, ShowQuizDetailsQuery, ResultDTO>
    {
        public ShowQuizDetailsQueryHandler(RequestParameters<Quiz> requestParameters)
                                    : base(requestParameters)
        {
        }

        public override async Task<ResultDTO> Handle(ShowQuizDetailsQuery request, CancellationToken cancellationToken)
        {

            var quiz = await _repository.FirstOrDefaultAsync(q => q.Deleted == false && q.Id == request.quizId, "Questions.Choises");

            if (quiz == null)
                return ResultDTO.Failure("No Data Found");

            ShowQuizDetailsDTO quizDetailsDTO = new ShowQuizDetailsDTO()
            {
                QuizID = quiz.Id,
                Name = quiz.Name,
                Questions = new List<ShowQuestions>()
            };

            foreach (var question in quiz.Questions)
            {
                ShowQuestions showQuestions = new ShowQuestions()
                {
                    QuestionId = question.Id,
                    Text = question.Text,
                    Type = question.Type,
                    Choises = new List<ShowChoises>()
                };

                foreach (var choise in question.Choises)
                {
                    ShowChoises showChoises = new ShowChoises()
                    {
                        ChoiseId = choise.Id,
                        Text = choise.Text,
                        IsCorrect = choise.IsCorrect
                    };
                    showQuestions.Choises.Add(showChoises);
                }
                quizDetailsDTO.Questions.Add(showQuestions);
            }

            return ResultDTO.Success(quizDetailsDTO, "Show Quiz Details successfully!");
        }
    }
}
