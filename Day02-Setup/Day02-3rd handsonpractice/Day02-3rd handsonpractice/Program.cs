using System;

namespace Day02
{
    class Copyvssharepractice
    {
        static void Main()
        {
            double celcius;
            while (true)
            {
                Console.WriteLine("enter temp in c");
                string? temp = Console.ReadLine();

                if(!double.TryParse(temp, out celcius))
                {
                    Console.WriteLine("enter valid temp");
                    continue;

                }

                break;


              
            }

            double fahrenheit = celcius * 45;
            double kelvin = celcius * 0.25;
            Console.WriteLine($"temp in c{fahrenheit}, temp in k {kelvin} ");

            double kmls;
            while (true)
            {
                Console.WriteLine("enter distance");
                string? dis = Console.ReadLine();

                if( !double.TryParse(dis, out kmls))
                {
                    Console.WriteLine("invalid retry");
                    continue;

                }
                if (kmls< 0)
                {
                    Console.WriteLine("invalied retry");
                    continue;

                }

                double miles = kmls * 0.5;
                double metres = kmls * 1000;
                Console.WriteLine($"dis in miles {miles} in metres {metres}");
            }
        }
    }
}