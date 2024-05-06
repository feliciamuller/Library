namespace Library.Models
{
    public class CustomerBookLoanViewModel
    {
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<BookLoan> BookLoans { get; set; }
        public IEnumerable<Book> Books { get; set; }
    }
}
