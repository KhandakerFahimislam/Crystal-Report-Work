using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Desh_Exam.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [Required, StringLength(100), Display(Name = "Book Name")]
        public string BookName { get; set; }
        [Required, StringLength(100), Display(Name = "Author Name")]
        public string AuthorName { get; set; }
        [Required, Column(TypeName = "date"), DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }
    public class BookDbContext : DbContext
    {
        public BookDbContext()
        {
            Database.SetInitializer(new BookInitializer());
        }
        public DbSet<Book> Books { get; set; }
    }
    public class BookInitializer : DropCreateDatabaseIfModelChanges<BookDbContext>
    {

        protected override void Seed(BookDbContext context)
        {
            if (context != null)
            {
                Book b1 = new Book { BookName = "Man and Superman", AuthorName = "G B Shaw", Date = new DateTime(2020, 02, 01), Quantity = 1 };
                Book b2 = new Book { BookName = "The Castle", AuthorName = "Franz Kalka", Date = new DateTime(2021, 02, 01), Quantity = 1 };
                Book b3 = new Book { BookName = "A Woman's Life", AuthorName = "Guy the Maupassaul", Date = new DateTime(2022, 02, 01), Quantity = 1 };

                context.Books.Add(b1);
                context.Books.Add(b2);
                context.Books.Add(b3);
                context.SaveChanges();
            }
            else
            {

            }
        }
    }
}