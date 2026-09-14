using System;
using System.Diagnostics.CodeAnalysis;
namespace Day03
{
    class example2
    {
        static void Main()
        {
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int sum = 0;                                            // giving a variable to store the sum of the numbers in the array
            foreach (int n in numbers)
                sum += n;
            Console.WriteLine("Sum: " + sum);


            //--------------------------------------------------


            int[] numbers2 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int max = numbers2[0];                                   // giving a variable to store the maximum number in the array
            foreach (int n in numbers2)
            {
                if (n > max)
                    max = n;                                          // if the current number is greater than the current maximum, update the maximum
            }
            Console.WriteLine("Max: " + max);

            //----------------------------------------------------------

            int evens = 0;                                                                      // giving a variable to store the count of even numbers in the array
            foreach (int n in numbers)
                if (n % 2 == 0) evens++;                                                              // if the current number is even, increment the count of even numbers)
            Console.WriteLine("Evens: " + evens);


            //-----------------------------------------------------------

            int target = 45;
            int foundat = -1;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] == target)
                {
                    foundat = i;
                    break;
                }
                Console.WriteLine(foundat > 0 ? $"Found at index {foundat}" : "Not found");


                //-----------------------------------------------------------

                Console.WriteLine("odd numbers only");
                foreach (int n in numbers)
                {
                    if (n % 2 != 0)
                        Console.WriteLine(n);
                }
                //-----------------------------------------------------------

                string joined = "";
                for (int j = 0; j < numbers.Length; j++)
                {
                    joined += numbers[j];
                    if (j < numbers.Length - 1)
                        joined += ", ";
                }
                Console.WriteLine($"joined numbers: {joined}");


            }




            }
        }
    }