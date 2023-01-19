using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Book
    {
        public Book()
        {
            Authors = new HashSet<Author>();
        }

        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Release date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [Display(Name = "Create date")]
        [DataType(DataType.Date)]
        public DateTime Created { get; set; }

        [Required]
        [StringLength(40)]
        [Display(Name = "Language")]
        public string Language { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        [ValidateNever]
        [StringLength(40)]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        [ValidateNever]
        public virtual BookDetails BookDetails { get; set; }

        [Display(Name = "Authors")]
        virtual public ISet<Author> Authors { get; set; }
    }
}
