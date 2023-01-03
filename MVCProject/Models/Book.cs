using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

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
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(40)]
        public string Category { get; set; }
        [Required]
        [StringLength(40)]
        public string Language { get; set; }

        [Display(Name = "Authors")]
        virtual public ISet<Author> Authors { get; set; }
    }
}
