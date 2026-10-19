using System;

namespace DebuggerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Debugger Demo Started");

            int number = 5;
            int result = Square(number);

            Console.WriteLine($"Square of {number} is {result}");

            Console.WriteLine("Debugger Demo Finished");
        }

        static int Square(int x)
        {
            return x * x + 1;
        }
    }
}
