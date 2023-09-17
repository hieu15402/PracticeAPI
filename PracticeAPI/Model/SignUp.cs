using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Model
{
    public class SignUp
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }
    }
}
