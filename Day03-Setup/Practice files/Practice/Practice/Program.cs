using System;

namespace Day03
{
    class program
    {
        static void  Mian (char ch)
        {
            if (char.IsUpper(ch))
            {
                Console.WriteLine($"An uppercase letter: {ch}");
            }
            else if (char.IsLower(ch))
            {
                Console.WriteLine($"A lowercase letter: {ch}");
            }
            else if (char.IsDigit(ch))
            {
                Console.WriteLine($"A digit: {ch}");
            }
            else
            {
                Console.WriteLine($"Not alphanumeric character: {ch}");
            }
        }
    }
}
