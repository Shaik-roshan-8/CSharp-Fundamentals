using System;

namespace Day01
{
    class OutputDemo
    {
        static void Main()
        {
            Console.WriteLine("plain text on its own line.");
            Console.Write("No newline here.");
            Console.WriteLine("so this continues the same line.");

            // Escape sequences
            Console.WriteLine("Tab\tseparated\tcolumns");
            Console.WriteLine("A\"quoted\" word");
            Console.WriteLine("c:\\Users\\Public\\file.txt");
            Console.WriteLine("Line one \nLine two");

            // Verbatim string - @ turns OFF escape processing
            Console.WriteLine(@"c:\Users\Public\file.txt");

            // Interpolation - the modern way to build text
            string name = "Asha";
              int age = 22;
            Console.WriteLine($"{name} is {age} years old.");
            Console.WriteLine($"The next year, she will be {age + 1} years old.");

            //Format specifiers inside interpolation
            decimal salary = 47500.5m;
            Console.WriteLine($"salary: {salary:C}");
            Console.WriteLine($"salary: {salary:N2}");
            Console.WriteLine($"Today: {DateTime.Now:dd-MMM-yyyy}");
            Console.WriteLine($"Padded: |{name,10}|");
            Console.WriteLine($"Padded: |{name,-10}|");










        }
    }
}
