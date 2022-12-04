using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;
using System.Xml.Linq;
using System.Reflection.PortableExecutable;
using System.Net.Http.Headers;
using System.IO;

namespace BookLibrary
{
    internal class Library
    {
        List<Book> Books = new List<Book>();
        public void AddBook(Book book) => Books.Add(book);

        public void ShowBook()
        {
            foreach (Book item in Books) Console.WriteLine(item);
        }

        public List<Book> FindAllBooksByName(string value)
        {
            List<Book> filteredbook = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Name.ToLower().Contains(value.ToLower())) filteredbook.Add(book);
            }
            return filteredbook;
        }

        public void RemoveAllBooksByName(string value)
        {
            Book removeBook = Books.Single(r => r.Name.ToLower().Contains(value.ToLower()));
            Books.Remove(removeBook);
            foreach (var item in Books) Console.WriteLine(item);
        }

        public List<Book> SearchBooks(string value)
        {
            List<Book> filteredbook = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.Name.ToLower().Contains(value.ToLower()) || book.AuthorName.ToLower().Contains(value.ToLower()) || Convert.ToString(book.PageCount).ToLower().Contains(value.ToLower()))
                    filteredbook.Add(book);
            }
            return filteredbook;
        }

        public List<Book> FindAllBooksByPageCountRange(int minPage, int maxPage)
        {
            List<Book> filteredbook = new List<Book>();
            foreach (Book book in Books)
            {
                if (book.PageCount >= minPage && book.PageCount <= maxPage) filteredbook.Add(book);
            }
            return filteredbook;
        }

        public void RemoveBookByCode(string value)
        {
            Book removeBook = Books.Single(r => r.Code.ToLower().Contains(value.ToLower()));
            Books.Remove(removeBook);
            foreach (var item in Books) Console.WriteLine(item);
        }
    }
}
