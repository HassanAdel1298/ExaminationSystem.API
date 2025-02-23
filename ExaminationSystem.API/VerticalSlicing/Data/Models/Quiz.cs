using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class Quiz : BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public DateTime DateOfQuiz { get; set; }

        public int InstructorID { get; set; }
        public virtual Instructor Instructor { get; set; }

        public virtual ICollection<Question> Questions { get; set; }


    }
}
