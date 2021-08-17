using System.ComponentModel.DataAnnotations;

namespace Contract.Dtos
{
    public class UserDto
    {
        [EmailAddress] 
        public string Email { get; set; }
    }
}