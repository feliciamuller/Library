using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Models
{
    public class BookLoan
    {
        [Key]
        public int BookLoanId { get; set; }
        [DisplayName("Låndatum")]
        public DateTime LoanDate { get; set; } = DateTime.Now;
        [ForeignKey("Book")]
        public int FKBookId { get; set; }
        public Book? Book { get; set; }
        [ForeignKey("Customer")]
        public int FKCustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
