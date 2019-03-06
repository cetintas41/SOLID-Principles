using System;
using System.Collections.Generic;

namespace _5_Dependency_Inversion_Principle
{

    public class Program
    {
        static void Main(string[] args)
        {
            var hs = new HumanService();
            var es = new EntityService();

            var author = new Author(hs, es);
            var book = new Book(es);

            Console.WriteLine($"This author is from {author.GetNationality()}");
            Console.WriteLine($"The book name is {book.GetName()}");
            Console.ReadKey();
        }
    }


    #region human
    public interface IHumanService
    {
        string GetNationality(string nat);
    }

    public class HumanService : IHumanService
    {
        public string GetNationality(string nat)
        {
            return $"Nationality is {nat}";
        }
    }
    #endregion

    #region entity
    public interface IEntityService
    {
        string GetName(string name);
    }

    public class EntityService : IEntityService
    {
        public string GetName(string name)
        {
            return $"Name is {name}";
        }
    }
    #endregion

    #region classes
    public class Author
    {
        private readonly IHumanService _humanService;
        private readonly IEntityService _entityService;

        public Author(IHumanService humanService, IEntityService entityService)
        {
            _humanService = humanService;
            _entityService = entityService;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public string GetNationality()
        {
            return _humanService.GetNationality("United States");
        }

        public virtual List<Book> Books { get; set; }
    }

    public class Book 
    {
        private readonly IEntityService _entityService;

        public Book(IEntityService entityService)
        {
            _entityService = entityService;
        }

        public string GetName()
        {
            return _entityService.GetName("White Fang");
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Author Author { get; set; }
    }


    #endregion
}
