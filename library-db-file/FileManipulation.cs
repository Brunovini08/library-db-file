using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_db_file
{
    public static class FileManipulation
    {
        public static void ReadFileOfBook(StreamReader streamReader, Library library)
        {
            using (streamReader)
            {
                try
                {
                    string content = streamReader.ReadToEnd();
                    if (content is not "")
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Tem livros no arquivo");
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
                                library.AddBook(bookUnit);
                            }
                        }
                        Console.WriteLine("Tem livros no arquivo");
                        Console.ResetColor();
                    }
                    else { }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        public static void CreateFileAndDirectory(string directoryPath, string fullPath)
        {
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
        }

        public static void SaveBooksInFile(StreamWriter streamWriter, Library library)
        {
            using (streamWriter)
            {
                try
                {
                    foreach (var item in library.FindAllBooks())
                    {
                        streamWriter.WriteLine(item.Save());
                    }
                    streamWriter.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
