using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class BookDetails
    {
        [ForeignKey("Book")]
        public int BookDetailsId { get; set; }
        [Display(Name = "Number Of Pages")]
        public int NumberOfPages { get; set; }
        [DataType(DataType.Currency)]
        [ValidateNever]
        public double Rating { get; set; }
        [ValidateNever]
        public virtual Book Book { get; set; }
    }
}
