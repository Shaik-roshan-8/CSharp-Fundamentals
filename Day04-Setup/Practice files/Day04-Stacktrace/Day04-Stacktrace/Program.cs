using System;
using System.Diagnostics.CodeAnalysis;
namespace Day04
{
    class Stacktrace
    {
        public static void Main()
        {
            int final = Result(10, 5);
            Console.WriteLine($"final : {final}");
        }
        public static int Result( int a , int b)
        {
            int Sum = a + b;
            return product(Sum, a, b);
        }
        
        public static int product ( int a , int b , int c )
        {
            int pro = a * b * c;
            return division (pro,b);
        }

        public static int division( int a , int b  )
        {
            int div = a / b;
            return div;
        }
 
    }
}