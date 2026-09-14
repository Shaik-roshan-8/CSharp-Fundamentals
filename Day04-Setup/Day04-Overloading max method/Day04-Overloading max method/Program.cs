using System;
namespace Day04
{
    class Overload
    {
        static void main()
        {
            Console.WriteLine(Max(24, 36));
            Console.WriteLine(Max(24, 56, 32));
            Console.WriteLine(Max(1, 2, 3, 4, 5, 6, 7, 8));

        }
        /// <summary>
        /// To find the max integer from two integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static int Max(int a , int b)
        {
            return (a >b) ? a : b;
        }
        /// <summary>
        /// To find the max integer from three integers
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        static int Max(int a , int b , int c)
        {
            return (Max(Max(a, b), c));
        }
        /// <summary>
        /// To find the max number inside an array
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        static int Max(params int[] numbers)
        {
            int max = numbers[0];
            foreach(int n in numbers)
            {
              if(n > max)
                    max = n;    
            }
            return max;
        }
    }
}