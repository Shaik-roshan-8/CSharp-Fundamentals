using System;
using System.Diagnostics;
namespace Day04
{
    class Fibonacci
    {
        static void Main()
        {
            Console.WriteLine(2);
            Stopwatch sw = new Stopwatch();

            //testing recursive for number1 = 35
            sw.Start();
            int rec35 = FibonacciRecursive(35);
            sw.Stop();
            Console.WriteLine($"Recursive fib(35)={rec35},Time = {sw.ElapsedMilliseconds}ms");

            //reset stopwatch
            sw.Reset();

            // testing recursive for number1= 40
            sw.Start();
            int rec40 = FibonacciRecursive(40);
            sw.Stop();
            Console.WriteLine($"recursive fib(40)={rec40}, Time = {sw.ElapsedMilliseconds}ms");

             //reset stopwatch
             sw.Reset();

            //testing Iterative for number1 = 35
            sw.Start();
            int iter35 = FibonacciIterative(35);
            sw.Stop();
            Console.WriteLine($"Iterative Fib(35) = {iter35} , Time = {sw.ElapsedMilliseconds}ms");

            //reset
            sw.Reset();

            //testing Iterarive for number 1 = 40
            sw.Start();
            int iter40 = FibonacciIterative(40);
            sw.Stop();
            Console.WriteLine($"Iterative Fib(40) = {iter40} , Time = {sw.ElapsedMilliseconds} ms");






        }
        static int FibonacciRecursive(int number1)
        {
            if (number1 <= 1) return number1;
            int fibrec = FibonacciRecursive(number1 - 1) + FibonacciRecursive(number1 - 2);
            return fibrec;

        }
        static int FibonacciIterative(int number1)
        {
            if (number1 <= 0)
            {
                return number1 ;
            }
            int a = 0;
            int b = 1;
            for(int i = 2; i < number1; i++)
            {
                int next = a + b;
                a = b;
                b = next;
            }
            return b;
        }
        
    }
}