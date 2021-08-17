using System.ComponentModel.DataAnnotations;

namespace Contract.Dtos
{
    public class LogInDto
    {
        [EmailAddress] 
        public string Email { get; set; }
        public string Password { get; set; }
    }
}