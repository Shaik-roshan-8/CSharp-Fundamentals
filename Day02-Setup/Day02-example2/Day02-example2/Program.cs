using System;

namespace Day02
{
    class Conversiondemo
    {
        static void Main()
        {
            // implicit
            int small = 42;
            int big = small; // implicit conversion from int to int
            double dbl = small; // implicit conversion from int to double
            Console.WriteLine($"Implicit : {big} , {dbl}");

            //explicit
            double price = 3.99;
            int whole = (int)price; // explicit conversion from double to int
            byte wrapped = (byte)price; // explicit conversion from int to byte
            Console.WriteLine($"explicit : {whole} , {wrapped}");

            //rounding
            Console.WriteLine($"rounded : {Math.Round(price)}");
            Console.WriteLine($"converted : {Convert.ToInt32(price)}");

            //string to number
            string good = "123";
            string bad = "abc";
            Console.WriteLine(int.Parse(good)); // converts string to int
            //Console.WriteLine(int.Parse(bad)); // throws exception because "abc" is not a valid number

            if(int.TryParse(bad,out int parsed))
                Console.WriteLine($"parsed : {parsed}");
            else
                Console.WriteLine($"abc is notr a number");

            // anything to string
            int n = 7;
            string text = n.ToString(); // converts int to string  
            Console.WriteLine($"as text : '{text}' has length {text.Length}");

            //floating point trap 
            Console.WriteLine(0.1 + 0.2 == 0.3); // false because of floating point precision issues
            Console.WriteLine(0.1m + 0.2m == 0.3m); // true because decimal type has higher precision for base-10 numbers



        }
    }
}
