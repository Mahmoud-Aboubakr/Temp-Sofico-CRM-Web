using System;

namespace Models
{
    public class AuthenticationModel
    {

        public string Client { get; set; } = "web";
        public string UserName { get; set; }
        public string Password { get; set; }
        
    }
    public class ResetPasswordModel
    {

        public int Userid { get; set; }

        public string UserName { get; set; }
        public string Password { get; set; }

    }
}
