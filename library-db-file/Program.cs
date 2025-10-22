using library_db_file;
using System;
using System.ComponentModel.Design;
using System.IO;

string filePath = "livros.txt";
string directoryPath = @"C:\Arquivos";
var fullPath = Path.Combine(directoryPath, filePath);

try
{
    if (!Directory.Exists(directoryPath))
    {
        Directory.CreateDirectory(directoryPath);
    }
    if (!File.Exists(fullPath))
    {
        File.Create(fullPath);
    }
}
catch (Exception exeception)
{
    Console.WriteLine(exeception.StackTrace);
    Console.WriteLine(exeception.Message);
}




List<Book> books = new List<Book>();
FileInfo fileInfo = new FileInfo(fullPath);

StreamReader streamReader = new StreamReader(fullPath);
using (streamReader)
{
    try
    {
        string content = streamReader.ReadToEnd();
        if (content is not null)
        {
            string[] booksSave = content.Split(';');
            foreach (var bookSave in booksSave)
            {
                string[] livros = bookSave.Split(',');
                if (livros.Length >= 3)
                {
                    string id = livros[0];
                    string title = livros[1];
                    string author = livros[2];
                    string category = livros[3];
                    Book bookUnit = new Book(int.Parse(id), title, author, category);
                    books.Add(bookUnit);
                }
            }
        }
        else { }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
StreamWriter streamWriter = new StreamWriter(fullPath);

int opcao = 1;
do
{
    Console.Clear();
    Console.WriteLine("LIVRARIA 5by5");
    Console.WriteLine("1 - Adicionar Livro");
    Console.WriteLine("2 - Listar livros");
    Console.WriteLine("3 - Atualizar livro");
    Console.WriteLine("4 - Remover livro");
    Console.WriteLine("0 - Sair");
    opcao = int.Parse(Console.ReadLine());
    switch (opcao)
    {
        case 1:
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
                var lastId = lastIdBook();
                Book b = new Book(lastId, title, author, category);
                books.Add(b);
                Console.WriteLine();
                Console.ReadKey();
                using (streamWriter)
                {
                    try
                    {
                        foreach (var item in books)
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
            break;
        case 2:
            {
                Console.Clear();
                Console.WriteLine("LISTANDO OS LIVROS");
                foreach (var bookUnit in books)
                {
                    Console.WriteLine(bookUnit);
                }
                Console.ReadKey();
            }
            break;
        case 3:
            Console.Clear();
            foreach (var item in books)
            {
                Console.WriteLine(item.ToString());
            }

            Console.Write("Digite o ID do livro que você deseja modificar: ");
            int id = int.Parse(Console.ReadLine());
            var book = books.Find(b => b.Id == id);
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
            break;
        case 4:
            Console.Clear();
            Console.WriteLine("REMOÇÃO DE LIVRO");
            foreach (var b in books)
            {
                Console.WriteLine(b);
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.Write("Digite o id do item que deseja remover: ");
            int idRemove = int.Parse(Console.ReadLine());

            var bookRemove = books.Find(b => b.Id == idRemove);
            if (bookRemove != null)
                books.Remove(bookRemove);
            else
                Console.WriteLine("O Livro não existe");
            using (streamWriter)
            {
                try
                {
                    foreach (var item in books)
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
            break;
    }
} while (opcao != 0);


int lastIdBook()
{
    var booksOrder = books.OrderBy(b => b.Id);
    if (booksOrder.Count() == 0) return 1;
    else
        return booksOrder.Last().Id + 1;
}
