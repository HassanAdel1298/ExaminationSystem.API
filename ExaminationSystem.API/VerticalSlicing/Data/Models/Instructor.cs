
namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class Instructor : BaseModel
    {

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public virtual ICollection<Quiz>? Quizzes { get; set; }

    }
}
