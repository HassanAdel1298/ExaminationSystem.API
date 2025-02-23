

namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class StudentAnswerQuestion : BaseModel
    {
        public int StudentID { get; set; }
        public virtual Student Student { get; set; }

        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        public string Answer { get; set; }
    }
}
