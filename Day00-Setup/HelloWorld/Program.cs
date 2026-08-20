using System;

namespace HelloWorld
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("What is your name? ");
            string name = Console.ReadLine();

            Console.Write("Which programming language do you want to learn? ");
            string language = Console.ReadLine();

            Console.WriteLine($"Hello, {name}! Welcome to C#.");
            Console.WriteLine($"You want to learn {language}. That's awesome");

            Console.WriteLine($"Today is {DateTime.Now:dddd, dd MMMM yyyy}.");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}


