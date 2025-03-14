

using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class StudentAnswerQuestion : BaseModel
    {
        [ForeignKey("Student")]
        public int StudentID { get; set; }
        public virtual User Student { get; set; }


        [ForeignKey("Question")]
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

        public string Answer { get; set; }
    }
}
