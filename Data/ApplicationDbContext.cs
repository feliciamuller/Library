using Library.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace Library.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BookLoan> BookLoans { get; set; }

        //Adding data to tables
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var customer1 = new Customer
            {
                CustomerId = 1,
                CustomerFirstName = "Felicia",
                CustomerLastName = "Müller",
                Email = "felicia@hotmail.com",
                MobileNumber = "0708150336"
            };

            var customer2 = new Customer
            {
                CustomerId = 2,
                CustomerFirstName = "Filip",
                CustomerLastName = "Styrman",
                Email = "filip@hotmail.com",
                MobileNumber = "0730937124"
            };

            var customer3 = new Customer
            {
                CustomerId = 3,
                CustomerFirstName = "Helena",
                CustomerLastName = "Westland",
                Email = "helena@hotmail.com",
                MobileNumber = "0705568681"
            };

            var book1 = new Book
            {
                BookId = 1,
                BookName = "Där kräftorna sjunger",
                AuthorName = "Delia Owens",
                ReleaseDate = new DateTime(2018, 08, 14),
                IsAvailable = true
            };

            var book2 = new Book
            {
                BookId = 2,
                BookName = "Bränn alla mina brev",
                AuthorName = "Alex Schulman",
                ReleaseDate = new DateTime(2022, 08, 18),
                IsAvailable = true
            };

            var book3 = new Book
            {
                BookId = 3,
                BookName = "I dina händer",
                AuthorName = "Malin Persson Giolito",
                ReleaseDate = new DateTime(2022, 02, 28),
                IsAvailable = true
            };

            var book4 = new Book
            {
                BookId = 4,
                BookName = "Hypnotisören",
                AuthorName = "Lars Kepler",
                ReleaseDate = new DateTime(2009, 07, 24),
                IsAvailable = true
            };

            modelBuilder.Entity<Customer>().HasData(customer1, customer2, customer3);
            modelBuilder.Entity<Book>().HasData(book1, book2, book3, book4);

            base.OnModelCreating(modelBuilder);
        }
    }
   
}