using System;
namespace Day03
{
    class pattern3
    {
        static void Main()
        {
            int rows = 5;

            for (int i = rows; i >= 1; i--)
            {
                for (int j = 1; j <= rows - i; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 1; k <= i; k++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        }
    }
}