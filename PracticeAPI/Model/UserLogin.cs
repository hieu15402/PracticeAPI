using System.ComponentModel.DataAnnotations;

namespace PracticeAPI.Model
{
    public class UserLogin
    {
        public string UserName { get; set; }

        public string Password { get; set; }
    }
}
