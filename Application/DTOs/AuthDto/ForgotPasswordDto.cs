using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.AuthDto
{
    public class ForgotPasswordDto
    {
        [EmailAddress]
        public string Email { get; set; }
    }
}
