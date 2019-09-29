using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twelve
{
    public delegate void SortHandler();
    class BookRepository
    {
        Book[] books;
        public BookRepository()
        {
            books = new Book[3];
            for (int i =0;i<3;i++)
            {
                books[i] = new Book();
            }

            books[0].Name = "Олеся";
            books[0].Author = "Куприн";
            books[0].Publisher = "ВВВ";
            books[1].Name = "Мастер и Маргарита";
            books[1].Author = "Булгаков";
            books[1].Publisher = "БББ";
            books[2].Name = "Война и мир";
            books[2].Author = "Толстой";
            books[2].Publisher = "AAA";
        }

        public SortHandler sortHandler;
        public void RegisterHandler(string type)
        {
            switch (type)
            {
                case "Name":
                    sortHandler = SortByName;
                    break;
                case "Author":
                    sortHandler = SortByAuthor;
                    break;
                case "Publisher":
                    sortHandler = SortByPublisher;
                    break;
            }
        }

        public void SortByName()
        {
            Console.WriteLine("Sorted by name");
            Array.Sort(books, new NameComparer());
        }
        public void SortByAuthor()
        {
            Console.WriteLine("Sorted by author");
            Array.Sort(books, new AuthorComparer());
        }
        public void SortByPublisher()
        {
            Console.WriteLine("Sorted by publisher");
            Array.Sort(books, new PublisherComparer());
        }

        public override string ToString()
        {
            string str = "";
            for (int i = 0; i<books.Length;i++)
            {
                str += string.Format("Book:\n{0}\n{1}\n{2}\n\n", books[i].Name, books[i].Author, books[i].Publisher);
            }
            return str;
        }

        public class NameComparer : IComparer<Book>
        {
            public int Compare(Book b1, Book b2)
            {
                return (string.Compare(b1.Name, b2.Name));
            }
        }
        public class AuthorComparer : IComparer<Book>
        {
            public int Compare(Book b1, Book b2)
            {
                return (string.Compare(b1.Author, b2.Author));                
            }
        }
        public class PublisherComparer : IComparer<Book>
        {
            public int Compare(Book b1, Book b2)
            {
                return (string.Compare(b1.Publisher, b2.Publisher));
            }
        }

    }
}
