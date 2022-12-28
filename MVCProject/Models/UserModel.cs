using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class UserModel
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required(ErrorMessage = "Please fill in your name!")]
        public string? Surname { get; set; }
        [Required(ErrorMessage = "Please fill in your surname!")]
        public string? FirstName { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Please fill in a valid e-mail!")]
        public string? Email { get; set; }
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }
        public GenderEnum Gender { get; set; }
        [Required(ErrorMessage = "Please fill in your login!")]
        public string? Login { get; set; }
        [Required(ErrorMessage = "Please fill in your password!")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
    }
}
