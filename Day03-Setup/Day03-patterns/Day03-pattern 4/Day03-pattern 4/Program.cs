using System;
namespace Day03
{
    class Pattern04
    {
        static void Main()
        {
            int rows = 5;

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= rows - i; j ++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= (2*i - 1); k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}