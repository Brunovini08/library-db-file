using library_db_file;

Library library = new Library();

string filePath = "livros.txt";
string directoryPath = @"C:\Arquivos";
var fullPath = Path.Combine(directoryPath, filePath);
FileManipulation.CreateFileAndDirectory(directoryPath, fullPath);
FileInfo fileInfo = new FileInfo(fullPath);
StreamReader streamReader = new StreamReader(fullPath);
FileManipulation.ReadFileOfBook(streamReader, library);
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
    if(opcao == 0)
    {
        FileManipulation.SaveBooksInFile(streamWriter, library);
    }
    switch (opcao)
    {
        case 1:
            Behavior.AddBookInLibrary(library, streamWriter);
            break;
        case 2:
            Behavior.ListBooksInLibrary(library);
            break;
        case 3:
            Behavior.UpdateBookInLibrary(library);
            break;
        case 4:
            Behavior.RemoveBookInLibrary(library, streamWriter);
            break;
    }
} while (opcao != 0);