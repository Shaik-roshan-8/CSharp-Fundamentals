using System;

namespace Personal_introduction_card_day01
{
    class card
    {
        static void Main()
        {
            Console.WriteLine("what is your name ?");
            string name = Console.ReadLine();

            Console.WriteLine("what is your city name ?");
            string city = Console.ReadLine();

            Console.WriteLine("what is your age ?");
            int age = int.Parse(Console.ReadLine());

            Console.WriteLine("   Personal introduction card ");
            Console.WriteLine("================================");
            Console.WriteLine($"| Date : {DateTime.Now.ToString("dddd,dd/MMMM/yyyy")} |");
            Console.WriteLine($"| Name : {name,21} |");
            Console.WriteLine($"| City : {city,21} |");
            Console.WriteLine($"| Age  : { age,21} |");
            Console.WriteLine("================================");

        }
    }
}