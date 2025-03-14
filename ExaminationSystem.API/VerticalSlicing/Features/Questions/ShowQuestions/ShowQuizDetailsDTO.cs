
namespace ExaminationSystem.API.VerticalSlicing.Features.Questions.ShowQuestions
{
    public class ShowQuizDetailsDTO
    {
        public int QuizID { get; set; }
        public string Name { get; set; }
        public List<ShowQuestions> Questions { get; set; }
        
    }

    public class ShowQuestions()
    {
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public int Type { get; set; }
        public List<ShowChoises> Choises { get; set; }
    }

    public class ShowChoises()
    {
        public int ChoiseId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
