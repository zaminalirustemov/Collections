using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLibrary
{
    internal class Book
    {
        public Book()
        {
            _id++;
            Id = _id;
        }
        private static int _id;
        public int Id { get; }
        public string Name { get; set; }
        public string AuthorName { get; set; }
        public int PageCount { get; set; }
        public string Code { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} --Name: {Name} ({AuthorName}) --Page: {PageCount} --Book code: {Code}";
        }
    }
}
