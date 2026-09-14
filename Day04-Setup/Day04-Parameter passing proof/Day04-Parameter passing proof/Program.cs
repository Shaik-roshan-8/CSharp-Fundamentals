using System;
    namespace Day04
{
    class Parameter
    {
        static void Main()
        {
            int a = 5;
            ByValue(a);
            Console.WriteLine($"original a ={a}");

            int b = 10;
            ByRef( ref b);
            Console.WriteLine($"original b = {b}");

            int c;
            ByOut( out c);
            Console.WriteLine($" c got the value from metho ");

    

        }
        static void ByValue(int number1)
        {
            Console.WriteLine(number1);
            number1 = 100;
            Console.WriteLine($"After modifying = {number1}");
        }
        static void ByRef(ref int number1)
        {
            Console.WriteLine(number1);
            number1 += 100;
            Console.WriteLine($"Modified number = {number1}");
        }
        static void ByOut(out int number1)
        {
            number1 = 156;
            Console.WriteLine(number1);
        }
        static void ()
   
    }
}