using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email address is required!")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string? Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
