using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        [DisplayName("Förnamn")]
        [Required(ErrorMessage = "Du måste ange ett förnamn")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Förnamn måste vara mellan 2 och 20 tecken")]
        public string CustomerFirstName { get; set; }
        [DisplayName("Efternamn")]
        [Required(ErrorMessage = "Du måste ange ett efternamn")]
        [StringLength(40, MinimumLength = 2, ErrorMessage = "Efternamn måste vara mellan 2 och 40 tecken")]
        public string CustomerLastName { get; set; }
        [DisplayName("Mobilnummer")]
        [Required(ErrorMessage = "Du måste ange ett mobilnummer")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobilnumret måste vara 10 siffror")]
        public string MobileNumber { get; set; }
        [DisplayName("Mejladress")]
        [EmailAddress(ErrorMessage = "Du måste skriva en giltig mejladress")]
        public string Email { get; set; }
        [DisplayName("Boklån")]
        public ICollection <BookLoan>? BookLoans { get; set; }
    }
}
