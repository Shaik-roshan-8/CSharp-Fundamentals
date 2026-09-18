using System;
using System.Net.Mime;
namespace Day05
{
    class ArrayStatistics
    {
        static void Main()
        {

            int[] numbers;
            numbers = new int[10];

            for (int i = 0; i < numbers.Length; i++)
            {
                while (true)
                {
                    Console.WriteLine($"Enter an integer {i + 1} ");
                    string? input = Console.ReadLine();

                    if (int.TryParse(input, out int value))
                    {
                        numbers[i] = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input");
                    }

                }
            }
            Console.WriteLine("\n Entered numbers :");
            foreach (int num in numbers)
            {
                Console.WriteLine(num + " ");
            }

            // Finding the sum 
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += numbers[i];
                
            }
            Console.WriteLine($"sum : {sum}");


            //Finding average
            int average = sum / numbers.Length;
            Console.WriteLine($"Average : {average}");


            //Finding maximun
            int maximum = numbers[0];  // So that we dont miss negative numbers
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > maximum)
                {
                    maximum = numbers[i];
                }
            }
            Console.WriteLine($"Maximum : {maximum}");

            //Finding minimum
            int minimum = numbers[0];
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < minimum)
                {
                    minimum = numbers[i];
                }
            }
            Console.WriteLine($"Minimum : {minimum}");

            //Count above average
            int count = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] > average)
                    count += 1;
            }
            Console.WriteLine($"Average : {average}");

            //Array reversed learnt from ai

            int[] copy = (int[])numbers.Clone();

            for (int i =0;  i < copy.Length/2; i++)
            {
                int temp = copy[i];
                copy[i] = copy[copy.Length - 1 - i];
                copy[copy.Length - 1 - i] = temp;
            }
            Console.WriteLine($"Reversed array :");
            foreach( int num in copy)
            {
                Console.WriteLine(num + " ");

            }


            // Finding 
            // Created a copy of array to reverse the values so here we can use it .
            Array.Sort(copy);
            int median;

            int n = copy.Length;
            // if odd
            if(n % 2 ==1 )
            {
                median = copy[n / 2];
            }
            else   //if even
            {
                median = (copy[(n / 2) - 1] + copy[n / 2]) / 2;
            }

            Console.WriteLine("median : " + median);
            



           
            


        }
    }
}