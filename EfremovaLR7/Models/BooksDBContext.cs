using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfremovaLR7.Models
{
    public class BooksDBContext : DbContext
    {

        public BooksDBContext() : this(false) { }
        public BooksDBContext(bool bFromScratch) : base()
        {
            if (bFromScratch)
            {
                //  Database.EnsureDeleted();
                //Database.EnsureCreated();
            }
        }

      
        public BooksDBContext(DbContextOptions<BooksDBContext> options)
            : base(options)
        {
           
        }

        // Коллекции сущностей
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
       
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder

               .UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Library;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

                // optionsBuilder

                //.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=Library;Trusted_Connection=True;");
            }
        }
      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Book>().Property(a => a.Title).IsRequired();
            modelBuilder.Entity<Book>().HasKey(a => a.Id);

            modelBuilder.Entity<Publisher>().Property(m => m.Name).IsRequired();
            modelBuilder.Entity<Publisher>().HasKey(m => m.Id);

            modelBuilder.Entity<Book>().HasOne<Publisher>(d => d.Publisher)
            .WithMany(a => a.Books).HasForeignKey(d => d.PublisherId);

            modelBuilder.Entity<Book>().HasData(
            new Book[]
            {
                new Book {Id = 1, Title = "Renault Sandero II Рестайлинг", Author= "sfsdfs",Year = 2000,  Genre="sfsd",PublisherId = 1}
            });

            modelBuilder.Entity<Publisher>().HasData(
            new Publisher[]
            {
                new Publisher {Id = 1, Name = "Renault", Address = "France", Number="dgdf" }
            });
        }
    }
}