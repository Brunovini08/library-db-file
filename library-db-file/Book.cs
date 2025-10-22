using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_db_file
{
    public class Book
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Author { get; private set; }
        public string Category { get; private set; }

        public Book(int id, string title, string author, string category)
        {
            this.Id = id;
            this.Title = title;
            this.Author = author;
            this.Category = category;
        }

        public override string ToString()
        {
            return $"ID:{this.Id}\nAutor:{this.Author}\nTítulo:{this.Title}\nCategoria:{this.Category}\n";
        }

        public void setTitle(string title)
        {
            this.Title = title;
        }

        public void UpdteInformation(string title, string author, string category)
        {
            this.Title = title;
            this.Author = author;
            this.Category = category;
        }

        public string Save()
        {
            return $"{this.Id},{this.Author},{this.Title},{this.Category};";
        }
    }
}
