using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVCProject.Models;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel()
        {
            AuthorsId = new List<string>();
        }

        [ValidateNever]
        public List<SelectListItem> Authors { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }

        [ValidateNever]
        [Required]
        public BookDetails BookDetails { get; set; }

        [Display(Name = "Authors")]
        public List<string> AuthorsId { get; set; }

    }
}
