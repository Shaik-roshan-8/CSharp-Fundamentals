using System;

namespace Day01
{
    class InputDemo
    {
        static void Main()
        {
            Console.Write("What is your name?");
            string name = Console.ReadLine();

            Console.Write("What year were you born?");
            string birthYeartext = Console.ReadLine(); // still a string 

            //we are converting text to int to calculate age

            int birthYear = int.Parse(birthYeartext); // convert text to int
            int age = DateTime.Now.Year - birthYear;

            Console.WriteLine();
            Console.WriteLine($"Hello {name}, you are about{age} years old.");
        }
    }
}