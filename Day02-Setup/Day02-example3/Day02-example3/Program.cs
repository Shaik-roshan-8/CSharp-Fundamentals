using System;

namespace Day02
{
    class SafeInput
    {
        static void Main()
        {
            int age;
            while (true)
            {
                Console.WriteLine("Enter your age (1-120):");
                string input = Console.ReadLine();

                if (!int.TryParse(input, out age))
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer.");
                    continue;   
                }
                if (age <1 || age >120)
                {
                    Console.WriteLine("Age must be between 1 and 120. Please try again.");
                    continue;
                
                }

                break;

            }

            Console.WriteLine($"Thank you. age is recorded as {age}.");
        }
    }
}

