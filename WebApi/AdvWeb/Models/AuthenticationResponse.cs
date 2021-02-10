using System.ComponentModel.DataAnnotations;
using AdvWeb.Entities;

namespace AdvWeb.Models
{
    public class AuthenticateResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string accessToken { get; set; }
        public string[] roles { get; set; }


        public AuthenticateResponse(User user, string token)
        {
            Id = user.Id;
            FirstName = user.FirstName;
            LastName = user.LastName;
            Username = user.Username;
            accessToken = token;
            roles = new string[]{ "ROLE_ADMIN" };
        }
    }

}
