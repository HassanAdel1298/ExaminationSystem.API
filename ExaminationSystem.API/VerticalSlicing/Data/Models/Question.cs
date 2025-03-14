
namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class Question : BaseModel
    {
        public string Text { get; set; }
        public int Type { get; set; }
        public int QuizID { get; set; }
        public virtual Quiz Quiz { get; set; }
        public virtual ICollection<Choise> Choises { get; set; }
        public virtual ICollection<StudentAnswerQuestion> StudentQuestions { get; set; }

    }
}
