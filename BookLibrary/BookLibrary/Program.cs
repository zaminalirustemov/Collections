using System.Collections;
using System.IO;
using System.Xml.Linq;

namespace BookLibrary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new();
            Book book2 = new();
            Book book3 = new();
            Book book4 = new();
            Book book5 = new();

            book1.Name = "Van Eyck";
            book2.Name = "Bataqlıq qızı";
            book3.Name = "Zeherlenmiş qelem";
            book4.Name = "Qendeharlı agent";
            book5.Name = "Brusseldə iki cenab";

            book1.AuthorName = "Till-Holger Borchert";
            book2.AuthorName = "Delia Ovens";
            book3.AuthorName = "Aqata Kristi";
            book4.AuthorName = "Chingiz Abdullayev";
            book5.AuthorName = "Erik Emmanuel Shmitt";

            book1.PageCount = 96;
            book2.PageCount = 432;
            book3.PageCount = 248;
            book4.PageCount = 240;
            book5.PageCount = 156;

            book1.Code = book1.Name.Substring(0, 2).ToUpper() + Convert.ToString(book1.Id);
            book2.Code = book2.Name.Substring(0, 2).ToUpper() + Convert.ToString(book2.Id);
            book3.Code = book3.Name.Substring(0, 2).ToUpper() + Convert.ToString(book3.Id);
            book4.Code = book4.Name.Substring(0, 2).ToUpper() + Convert.ToString(book4.Id);
            book5.Code = book5.Name.Substring(0, 2).ToUpper() + Convert.ToString(book5.Id);

            Library library = new Library();
            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);
            library.AddBook(book5);

            string choise;
            do
            {
                Console.WriteLine("====================================");
                Console.WriteLine("        Menu:");
                Console.WriteLine("[0] - Show Book\r\n[1] - Find All Books By Name\r\n[2] - Remove All Books By Name\r\n[3] - Search Books\r\n[4] - Find All Books By Page Count Range\r\n[5] - Remove Book By Code\r\n[6] - Console clear\r\n[7] - Shortcut to quit the program.\"");
                Console.WriteLine("====================================");
                Console.Write("Please select:"); choise = Console.ReadLine();
                Console.WriteLine("------------------------------------");
                switch (choise)
                {
                    case "0":
                        library.ShowBook();
                        break;
                    case "1":
                        Console.Write("Enter any part of the book name:");
                        string input1 = Console.ReadLine();
                        Console.WriteLine("***********************************");
                        foreach (var item in library.FindAllBooksByName(input1)) Console.WriteLine(item);
                        break;
                    case "2":
                        Console.Write("Enter any part of the book name you want to remove:");
                        string input2 = Console.ReadLine();
                        Console.WriteLine("***********************************");
                        try
                        {
                            library.RemoveAllBooksByName(input2);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no such book");
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown error");
                            Console.ResetColor();
                        }
                        break;
                    case "3":
                        Console.Write("Enter text in any of Name,AuthorName,PageCount values:");
                        string input3 = Console.ReadLine();
                        Console.WriteLine("***********************************");
                        foreach (var item in library.SearchBooks(input3)) Console.WriteLine(item);
                        break;
                    case "4":
                        bool check;
                        int min;
                        int max;
                        do
                        {
                            Console.Write("Enter minimum page:");
                            check = int.TryParse(Console.ReadLine(), out min);
                            Console.Write("Enter maximum page:");
                            check = int.TryParse(Console.ReadLine(), out max);
                            if (min <= 0 || max <= 0)
                            {
                                check = false;
                                Console.WriteLine("Error: Page count is a number and must be greater than 0 ");
                            }
                        } while (!check);

                        Console.WriteLine("***********************************");
                        foreach (var item in library.FindAllBooksByPageCountRange(min, max)) Console.WriteLine(item);
                        break;
                    case "5":
                        Console.Write("Enter any part of the book code you want to remove:");
                        string input5 = Console.ReadLine();
                        Console.WriteLine("***********************************");
                        try
                        {
                            library.RemoveBookByCode(input5);
                        }
                        catch (InvalidOperationException)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("There is no such book");
                            Console.ResetColor();
                        }
                        catch (Exception)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Unknown error");
                            Console.ResetColor();
                        }
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    default:
                        break;
                }
            } while (choise != "7");
        }
    }
}