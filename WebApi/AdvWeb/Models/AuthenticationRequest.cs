using System.ComponentModel.DataAnnotations;

namespace AdvWeb.Models
{
    public class AppSettings
    {
        public string Secret { get; set; }
    }

    public class AuthenticateRequest
    {
        [Required]
        public string username { get; set; }

        [Required]
        public string password { get; set; }
    }

}
