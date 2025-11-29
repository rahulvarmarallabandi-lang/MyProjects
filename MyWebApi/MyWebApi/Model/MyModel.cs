using System.ComponentModel.DataAnnotations;

namespace MyWebApi.Model
{
    public class MyModel
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }

    }
    public class User
    {
        public int Id { get; set; }

        
        public string Name { get; set; }

       
        public string email { get; set; }

        
        public string Password { get; set; }
    }
    public class LoginDto
    {
        public string UserId { get; set; }
        public string Password { get; set; }
    }

}
