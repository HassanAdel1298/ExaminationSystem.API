using MediatR;
using ExaminationSystem.API.VerticalSlicing.Common.DTOs;
using ExaminationSystem.API.VerticalSlicing.Common.Helpers;
using ExaminationSystem.API.VerticalSlicing.Common;
using ExaminationSystem.API.VerticalSlicing.Data.Models;
using ExaminationSystem.API.VerticalSlicing.Features.Questions.CheckQuestionExist;

namespace ExaminationSystem.VerticalSlicing.Features.Questions.AnswerQuestions.Commands
{
    public class AnswerQuestionsCommand() : IRequest<ResultDTO>
    {
        public List<AnswerQuestion> AnswerQuestions { get; set; }

    }

    public class AnswerQuestion()
    {
        public int QuestionID { get; set; }
        public string Answer { get; set; }
    }

    public class AnswerQuestionsCommandHandler : BaseRequestHandler<StudentAnswerQuestion, AnswerQuestionsCommand, ResultDTO>
    {
        public AnswerQuestionsCommandHandler(RequestParameters<StudentAnswerQuestion> requestParameters)
                                    : base(requestParameters)
        {
        }
        public override async Task<ResultDTO> Handle(AnswerQuestionsCommand request, CancellationToken cancellationToken)
        {
            List<StudentAnswerQuestion> answerQuestions = new List<StudentAnswerQuestion>();

            foreach (var answerQuestionDto in request.AnswerQuestions)
            {
                var CheckQuestionExist = await _mediator.Send(new CheckQuestionExistCommand(answerQuestionDto.QuestionID));

                if (!CheckQuestionExist.IsSuccess)
                {
                    return ResultDTO.Failure("Quit is not exists!");
                }

                StudentAnswerQuestion answerQuestion = new StudentAnswerQuestion()
                {
                    Answer = answerQuestionDto.Answer,
                    QuestionID = answerQuestionDto.QuestionID,
                    Deleted = false
                };
                int userid = 0;
                bool checkLogin = int.TryParse(_userState.Id, out userid);
                if (checkLogin)
                {
                    answerQuestion.StudentID = userid;
                }

                answerQuestions.Add(answerQuestion);
            }

            _repository.CreateListAsync(answerQuestions);

            return ResultDTO.Success(true, "Answer Questions successfully!");
        }
    }
}
