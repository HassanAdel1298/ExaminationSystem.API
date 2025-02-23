

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExaminationSystem.API.VerticalSlicing.Data.Models
{
    public class Choise : BaseModel
    {

        public string Text { get; set; }
        public bool IsCorrect { get; set; }
        public int QuestionID { get; set; }
        public virtual Question Question { get; set; }

    }
}
