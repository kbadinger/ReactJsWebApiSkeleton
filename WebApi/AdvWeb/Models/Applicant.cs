using System;
namespace AdvWeb.Models
{
    public class Applicant
    {

        public int ApplicantId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime CreatedDate { get; set; }
        public int EmailVerified { get; set; }
        public string EmailVerificationToken { get; set; }


    }
}
