using System;
using System.Collections.Generic;
using System.Linq;

namespace Single_Responsibility_Principle
{
    public class Program
    {
        static void Main(string[] args)
        {
            var author = new Author
            {
                Id = 1,
                Name = "Jack London"
            };

            author.Books = author.Books ?? new List<Book>();

            var book = new Book
            {
                Id = 1,
                Author = author,
                Name = "Martin Eden",
            };

            author.AddBook(book);

            var book2 = new Book
            {
                Id = 2,
                Author = author,
                Name = "White Fang",
            };

            author.AddBook(book2);

            Console.Write($"{author.Name} has {author.Books.Count()} book(s).");
            Console.ReadKey();

            book.DeleteBook(2);

            Console.Write($"{author.Name} has {author.Books.Count()} book(s).");
            Console.ReadKey();
        }
    }

    #region classes

    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Book> Books { get; set; }

        public void AddBook(Book book)
        {
            Books.Add(book);
        }
    }

    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author Author { get; set; }

        public Book GetBook(int bookId)
        {
            return Author.Books.First(i => i.Id == bookId);
        }

        public void DeleteBook(int bookId)
        {
            var book = GetBook(bookId);

            if (book == null)
                return;

            Author.Books.Remove(book);
        }
    }

    #endregion
}
