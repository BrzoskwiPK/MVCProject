using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class RegisterViewModel
    {
        [Display(Name = "First name")]
        [Required(ErrorMessage = "First name is required!")]
        [DataType(DataType.Text)]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "Email address is required!")]
        [MinLength(5)]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email address")]
        public string? EmailAddress { get; set; }
        [Required(ErrorMessage = "Date of birth is required!")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of birth")]
        public DateTime DateOfBirth { get; set; }
        [Required(ErrorMessage = "Gender is required!")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        [MinLength(5)]
        public string? Password { get; set; }
        [Display(Name = "Confirm password")]
        [Required(ErrorMessage = "Confirm password is required!")]
        [DataType(DataType.Password)]
        [MinLength(5)]
        [Compare("Password", ErrorMessage = "Password do not match!")]
        public string? ConfirmPassword { get; set; }
    }
}
