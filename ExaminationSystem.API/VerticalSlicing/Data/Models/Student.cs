

namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class Student : BaseModel
    {
        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<StudentAnswerQuestion>? StudentQuestions { get; set; }

    }
}
