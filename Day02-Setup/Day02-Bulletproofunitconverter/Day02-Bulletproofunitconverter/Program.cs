using System;

namespace Day02
{
    class Bulletproof
    {
        static void Main()
        {
            double  celcius ; // using double because can store decimals we can use int but for measurements the precision can roundup to value.
            while (true)
            {
                Console.WriteLine("Enter temparature in celcius");
                string? temparature = Console.ReadLine();

                if(!double .TryParse(temparature, out celcius))
                {
                    Console.WriteLine("Enter valid temparature");
                    continue;

                }

                break;

                

            }

            double fahrenheit = (celcius * 9 / 5) + 32;
            double kelvin = celcius + 273.15;
            Console.WriteLine($"temparature in fahrenheit is {fahrenheit} , temparature in kevin is {kelvin}");


            //convering kilometers to miles and metres

            double kilometers;
            while (true)
            {
                Console.WriteLine("Enter distance in kilometers");
                string? distance = Console.ReadLine();

                if(!double .TryParse(distance, out kilometers))
                {
                    Console.WriteLine("Enter valid distance");
                    continue;
                }

                if (kilometers<0)
                {
                    Console.WriteLine("Distance can not be negative or 0 ");
                    continue;
                }

                break;


            }

            double miles = kilometers * 0.621371;
            double metres = kilometers * 1000;

            Console.WriteLine($"Distance in miles = {miles}, distance in metres = {metres}");


        }
    }
}