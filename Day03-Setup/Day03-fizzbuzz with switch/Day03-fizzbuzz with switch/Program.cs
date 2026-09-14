using System;
namespace Day03
{
    class Fizzbuzz
    {
        static void Main(string[] args)
        {
            for (int i = 1; i <= 100; i++)
            {
                switch (i)
                {
                    case int n when (n % 3 == 0 && n % 5 == 0):
                        Console.WriteLine("FizzBuzz");
                        break;
                    case int n when (n % 3 == 0):
                        Console.WriteLine("Fizz");
                        break;
                    case int n when (n % 5 == 0):
                        Console.WriteLine("Buzz");
                        break;
                        default:
                        Console.WriteLine(i);
                        break;
                }
            }   
            
        }
    }
}