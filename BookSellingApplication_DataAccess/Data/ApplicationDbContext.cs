using BookSellingApplication_Model;
using BookSellingApplication_Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookSellingApplication_DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Cart> CartDetails { get; set; }
        public DbSet<Purchase> PurchaseDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-74F4VO2;database=BookSellingApplication;TrustServerCertificate=True;Trusted_Connection=True;");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasKey(u => u.Book_Id);
            modelBuilder.Entity<Book>().Property(u => u.Title).IsRequired();
            modelBuilder.Entity<Book>().Property(u => u.Available_Quantity).IsRequired();
            modelBuilder.Entity<Book>().Property(u => u.Password).IsRequired();


            modelBuilder.Entity<Admin>().HasKey(u => u.Admin_Id);
            modelBuilder.Entity<Admin>().Property(u => u.UserName).IsRequired();
            modelBuilder.Entity<Admin>().Property(u => u.Password).IsRequired();


            modelBuilder.Entity<Category>().HasKey(u => u.Category_Id);
            modelBuilder.Entity<Category>().Property(u => u.Category_Name).IsRequired();


            modelBuilder.Entity<Customer>().HasKey(u => u.Customer_Id);
            modelBuilder.Entity<Customer>().Property(u => u.FirstName).IsRequired();
            modelBuilder.Entity<Customer>().Property(u => u.LastName).IsRequired();
            modelBuilder.Entity<Customer>().Property(u => u.Email).IsRequired();
            modelBuilder.Entity<Customer>().Property(u => u.Address).IsRequired();
            modelBuilder.Entity<Customer>().Property(u => u.Password).IsRequired();


            modelBuilder.Entity<Purchase>().HasKey(u => u.Purchase_Id);
            modelBuilder.Entity<Purchase>().Property(u => u.CartId).IsRequired();
            modelBuilder.Entity<Purchase>().Property(u => u.Purchase_Quantity).IsRequired();


            modelBuilder.Entity<Cart>().HasKey(u => u.Id);
            modelBuilder.Entity<Cart>().Property(u => u.Id).IsRequired();
            modelBuilder.Entity<Cart>().Property(u => u.Book_Id).IsRequired();
            modelBuilder.Entity<Cart>().Property(u => u.Title).IsRequired();
            modelBuilder.Entity<Cart>().Property(u => u.Quantity).IsRequired();
            modelBuilder.Entity<Cart>().Property(u => u.CustomerId).IsRequired();
            modelBuilder.Entity<Cart>().HasOne(u => u.BookObj).WithMany(u => u.CartItems).HasForeignKey(u => u.Book_Id);
            modelBuilder.Entity<Cart>().HasOne(u => u.CustomerObj).WithMany(u => u.cartCustomers).HasForeignKey(u => u.CustomerId);



            modelBuilder.Entity<Category>().HasData(
                new Category { Category_Id = 1, Category_Name = "Historic" },
                new Category { Category_Id = 2, Category_Name = "Thriller" },
                new Category { Category_Id = 3, Category_Name = "Mystery" },
                new Category { Category_Id = 4, Category_Name = "Fiction" },
                new Category { Category_Id = 5, Category_Name = "Action" },
                new Category { Category_Id = 6, Category_Name = "Action & Adventure" },
                new Category { Category_Id = 7, Category_Name = "Comics" },
                new Category { Category_Id = 8, Category_Name = "Fantasy" },
                new Category { Category_Id = 9, Category_Name = "Horror" },
                new Category { Category_Id = 10, Category_Name = "Romantic" },
                new Category { Category_Id = 11, Category_Name = "Biography" },
                new Category { Category_Id = 12, Category_Name = "Science" }
                );

        }
    }
}
