using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_db_file
{
    public static class Behavior
    {
        public static void AddBookInLibrary(Library library, StreamWriter streamWriter)
        {
            Console.Clear();
            Console.Write("Digite o título do livro: ");
            string title = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite o autor do livro: ");
            string author = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Digite a categoria do livro: ");
            string category = Console.ReadLine();
            var lastId = LastIdBook(library);
            Book b = new Book(lastId, title, author, category);
            library.AddBook(b);
            Console.WriteLine();
            Console.ReadKey();
            FileManipulation.SaveBooksInFile(streamWriter, library);
        }
        public static void ListBooksInLibrary(Library library)
        {
            Console.Clear();
            Console.WriteLine("LISTANDO OS LIVROS");
            foreach (var bookUnit in library.FindAllBooks())
            {
                Console.WriteLine(bookUnit);
            }
            Console.ReadKey();
        }
        public static void UpdateBookInLibrary(Library library)
        {
            Console.Clear();
            foreach (var item in library.FindAllBooks())
            {
                Console.WriteLine(item.ToString());
            }

            Console.Write("Digite o ID do livro que você deseja modificar: ");
            int id = int.Parse(Console.ReadLine());
            var book = library.FindAllBooks().Find(b => b.Id == id);
            Console.WriteLine(book);
            Console.Clear();
            if (book is null)
            {
                Console.WriteLine($"Nenhum livro encontrado com o ID: {id}");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Caso não queira mudar a informação, aperte ENTER");
                Console.Write("Digite o título do livro: ");
                string title = Console.ReadLine();
                Console.WriteLine();
                Console.Write("Digite o autor do livro: ");
                string author = Console.ReadLine();
                Console.WriteLine();
                Console.WriteLine("Digite a categoria do livro: ");
                string category = Console.ReadLine();
                book.UpdteInformation((title != "" ? title : book.Title), (author != "" ? author : book.Author), (category != "" ? category : book.Category));
                Console.WriteLine();
                Console.WriteLine("Livro modificado com sucesso!");
                Console.WriteLine();
                Console.WriteLine(book);
            }
        }
        public static void RemoveBookInLibrary(Library library, StreamWriter streamWriter)
        {
            Console.Clear();
            Console.WriteLine("REMOÇÃO DE LIVRO");
            foreach (var b in library.FindAllBooks())
            {
                Console.WriteLine(b);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Digite o id do item que deseja remover: ");
            int idRemove = int.Parse(Console.ReadLine());

            var bookRemove = library.FindAllBooks().Find(b => b.Id == idRemove);
            if (bookRemove != null)
                library.RemoveBook(bookRemove);
            else
                Console.WriteLine("O Livro não existe");
            using (streamWriter)
            {
                try
                {
                    foreach (var item in library.FindAllBooks())
                    {
                        streamWriter.WriteLine(item.Save());
                    }
                    Console.WriteLine("Livro adicionado com sucesso");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
        public static int LastIdBook(Library library)
        {
            var booksOrder = library.FindAllBooks().OrderBy(b => b.Id);
            if (booksOrder.Count() == 0) return 1;
            else
                return booksOrder.Last().Id + 1;
        }
    }
}
