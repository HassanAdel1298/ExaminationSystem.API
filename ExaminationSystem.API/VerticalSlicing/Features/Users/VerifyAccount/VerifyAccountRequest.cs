using System.ComponentModel.DataAnnotations;

namespace ExaminationSystem.API.VerticalSlicing.Features.Users.VerifyAccount
{
    public class VerifyAccountRequest
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string OTP { get; set; }
    }
}
