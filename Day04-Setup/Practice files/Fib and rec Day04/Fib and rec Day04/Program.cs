using System;
namespace Day04
{
    class practice
    {

        static void Main()
        {
            
            Console.WriteLine(fib(4));
        }
        static long fib(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            long a = 0, b = 1;
            for (int i = 2; i <= n; i++)
            {
                long next = a + b;
                a = b;
                b = next;
            }
            return b;
        }
    }
}