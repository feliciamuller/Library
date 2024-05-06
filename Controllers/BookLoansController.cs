using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class BookLoansController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BookLoansController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> GetBookLoans()
        {
            var bookLoans = await _context.BookLoans
                .Include(b => b.Book)
                .Include(c => c.Customer)
                .ToListAsync();
            return View(bookLoans);
        }
        public async Task<IActionResult> GetBookLoansCustomer(int id)
        {
            var customer = await _context.Customers.ToListAsync();
            ViewBag.AllCustomers = customer;

            var selectedCustomer = await _context.BookLoans
                .Include(b => b.Book)
                .Include(c => c.Customer)
                .Where(c => c.FKCustomerId == id)
                .ToListAsync();

            return View(selectedCustomer);
        }
        [HttpGet]
        public IActionResult CreateBookLoan()
        {
            var customers = _context.Customers.ToList();
            ViewBag.Customers = customers;

            //only adding the available books to list
            var books = _context.Books.Where(a => a.IsAvailable == true).ToList();
            ViewBag.Books = books;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBookLoan(BookLoan bookLoan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookLoan);
                //get the selected book
                var selectedBook = await _context.Books.FindAsync(bookLoan.FKBookId);
                if (selectedBook != null)
                {
                    selectedBook.IsAvailable = false;
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookLoan);
        }
    }
}
