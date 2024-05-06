using Library.Data;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _context.Update(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetCustomers));
            }
            return View(customer);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Customer customer, int id)
        {
            if (id != customer.CustomerId)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                _context.Remove(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(GetCustomers));
            }
            return View(customer);
        }

        public async Task<IActionResult> GetCustomers()
        {
            return View(await _context.Customers.ToListAsync());
        }
        [HttpGet]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var customer = await _context.Customers.ToListAsync();
            ViewBag.AllCustomers = customer;

            var oneCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            return View(oneCustomer);
        }
    }
}
