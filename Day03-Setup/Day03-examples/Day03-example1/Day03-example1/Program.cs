using System;
namespace Day03
{
    class calculator
    {
        static void Main()
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine(" =====calculator=====");
                Console.WriteLine("1. Add    3.multiply");
                Console.WriteLine("2. Subtract 4. Divide");
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                if (choice == "5")
                {
                    running = false;
                    continue;
                }
                else if (choice != "1" && choice != "2" && choice != "3" && choice != "4")
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;

                }
                Console.WriteLine("Enter number 1:");
                double number1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter number 2:");
                double number2 = double.Parse(Console.ReadLine());

                switch (choice)
                {
                    case "1":
                        Console.WriteLine($"Result: {number1 + number2}");
                        break;
                    case "2":
                        Console.WriteLine($"Result: {number1 - number2}");
                        break;
                    case "3":
                        Console.WriteLine($"Result: {number1 * number2}");
                        break;
                    case "4":
                        Console.WriteLine($"Result: {number1 / number2}");
                        break;
                }
                Console.WriteLine("good bye");
            }



        }
               /*static double readnumber(string prompt)
               {
            double value;
                while (true)
            {
                Console.WriteLine(prompt);
                if (double.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                    .WriteLine("Invalid input. Please enter a valid number.");
                }

            }*/

    }
} 

