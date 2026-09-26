using System;
namespace Day06
{
    public class Book
    {
        public string Isbn { get;  }
        public string Title { get; private set;  }
        public string Author { get; private set; }
        public bool IsAvailable { get; private set; }
        public int TimesBorrowed { get; private set; }

        private static int _totalbooks = 0;
        public static int TotalBooks => _totalbooks;

        public Book(string isbn , string title , string author)
        {
            if(string.IsNullOrWhiteSpace(isbn) || isbn.Length!=13 || !IsAllDigits(isbn))
            {
                throw new ArgumentException("ISBN must be exactly 13 digits ", nameof(isbn));
            }
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("Title can not be empty", nameof(title));
            }
            if(string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentException("Author can not be empty", nameof(author));
            }

            Isbn = isbn;
            Title = title;
            Author = author;
            IsAvailable = true;
            TimesBorrowed = 0;
            _totalbooks++;
        }
        private static bool IsAllDigits(string s)
        {
            foreach (char c in s)
            {
                if (!char.IsDigit(c))
                    return false;
            }
            return true;
            
        }
        public void borrow()
        {
            if(!IsAvailable)
            {
                throw new InvalidOperationException($"'{Title}' is already borrowed.");
            }
            IsAvailable = false;
            TimesBorrowed++;
        }
        
        public void Return()
        {
            if(IsAvailable)
            {
                throw new InvalidOperationException($"'{Title}' was not borrowed, so it cannot be returned.");
            }
            IsAvailable = true;

        }

        public override string ToString()
        {
            string status = IsAvailable ? "Available" : "Borrowed";
            return $"{Isbn,-15} {Title,-25} {Author,-20} {status,-12} Borrowed{TimesBorrowed} times";
        }

    }
    public class Program
    {
        static void Main()
        {
            Book book1 = new Book("9780132350884", "Clean Code", "Robert C. Martin");
            Book book2 = new Book("9780201633610", "Design Patterns", "Gang of Four");
            Book book3 = new Book("9780596007126", "Head First Design Pats", "Freeman & Robson");
            Book book4 = new Book("9780134685991", "Effective Java", "Joshua Bloch");
            Book book5 = new Book("9781491950357", "Building Microservices", "Sam Newman");
            Book book6 = new Book("9780135957059", "The Pragmatic Programmer", "Hunt & Thomas");

            Book[] books = { book1, book2, book3, book4, book5, book6 };

            book1.borrow();
            book2.borrow();
            book3.borrow();

            book1.Return();
            book2.Return();

            book1.borrow();

            Console.WriteLine("Library collection");
            foreach(Book book in books)
            {
                Console.WriteLine(book);
            }
            Console.WriteLine();
            Console.WriteLine($"Total books created = {Book.TotalBooks}");


        }
    }
}