using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [DisplayName("Titel")]
        [Required(ErrorMessage = "Boken måste ha ett namn")]
        [StringLength(130, MinimumLength = 1, ErrorMessage = "Namnet på boken måste vara mellan 1 och 130 tecken")]
        public string BookName { get; set; }
        [DisplayName("Författare")]
        [Required(ErrorMessage = "Boken måste ha en författare")]
        [StringLength(60, MinimumLength = 2, ErrorMessage = "Namnet på författaren måste vara mellan 2 och 60 tecken")]
        public string AuthorName { get; set; }
        [DisplayName("Lanseringsdatum")]
        [Required(ErrorMessage = "Boken måste ha ett lanseringsdatum")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [DisplayName("Tillgänglig för lån")]
        public bool IsAvailable { get; set; } = true;
        [DisplayName("Boklån")]
        public ICollection<BookLoan>? BookLoans { get; set; }
    }
}
