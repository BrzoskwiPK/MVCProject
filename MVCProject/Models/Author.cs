using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    [Table("Authors")]
    public class Author
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("FirstName")]
        [StringLength(40)]
        public string FirstName { get; set; }

        [Required]
        [Column("LastName")]
        [StringLength(40)]
        public string LastName { get; set; }

        virtual public ISet<Book> Books { get; set; }
    }
}
