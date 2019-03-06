using System;
using System.Collections.Generic;
using System.Linq;

namespace Liskov_Substitution_Principle
{
     public class Program
     {
        static void Main(string[] args)
        {
            var author = new Author
            {
                Id = 1,
                Name = "Jack",
                Surname = "London"
            };

            var book = new Book
            {
                Id = 1,
                Author = author,
                Name = "Martin Eden",
            };

            Console.WriteLine($"Book name: {book.GetName()}");
            Console.WriteLine($"Author name: {author.GetName()}");
            Console.WriteLine($"Author nationality: {author.GetNationality()}");
            Console.Read();
        }
    }

    #region classes

    public interface IHuman
    {
        string GetNationality();
    }

    public abstract class BaseEntity
    {
        public abstract string GetName();
    }

    public class Author : BaseEntity, IHuman
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public virtual List<Book> Books { get; set; }

        public override string GetName()
        {
           return $"{Name} {Surname}";
        }

        public string GetNationality()
        {
            return "United States";
        }
    }

    public class Book : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author Author { get; set; }

        public override string GetName()
        {
            return Name;
        }
    }

   
    #endregion
}
