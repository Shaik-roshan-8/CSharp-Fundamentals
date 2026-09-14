using System;

namespace Day03
{
    class nestedloops
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Enter the number of rows: ");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of colums");
            int colums = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("symbol: ");
            string symbol = Console.ReadLine();

            for (int i = 1; i <= rows; i++)
            {
                for (int j = 1; j <= colums; j++)
                {
                    Console.Write(symbol);
                }
                Console.WriteLine();
            }
        }
    }
}