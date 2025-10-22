using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_db_file
{
    public class Library
    {
        public List<Book> Books { get; set; }
        public Library()
        {
            Books = new List<Book>();
        }

        public void AddBook(Book book)
        {
            this.Books.Add(book);
        }

        public void RemoveBook(Book book)
        {
            this.Books.Remove(book);
        }

        public Book FindBookById(int id)
        {
            return this.Books.Find(b => b.Id == id);
        }

        public List<Book> FindAllBooks()
        {
            return this.Books.ToList();
        }

        public Book UpdateInfoBook(Book book)
        {
            var bookSave = this.Books.Find(b => b.Id ==  book.Id);
            bookSave = book;
            return bookSave;
        }
    }
}
