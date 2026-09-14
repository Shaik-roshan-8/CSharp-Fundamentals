using System;
namespace Day03
{
    class pattern4
    {
        static void Main()
        {
            int rows = 5;
            for (int i =1; i <= rows; i++)
            {
                for (int j =1; j <= i; j++)
                {
                    Console.Write(j);
                }
                Console.WriteLine();
            }
        }
    }
}