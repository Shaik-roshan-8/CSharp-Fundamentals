using System;
namespace Day04
{
    class Example
    {
        static void Main()
        {
            Console.Write("Enter basic salary: ");
            decimal basic =decimal.Parse(Console.ReadLine());
            decimal hra = basic * 0.40m;
            decimal transport = 1600m;
            decimal gross = basic + hra + transport;
            decimal pf = basic * 0.12m;
            decimal proftax = 200m;
            decimal taxable = gross - pf;
            decimal incometax = 0m;
            if (taxable > 100000) incometax = (taxable - 100000m) * 0.30m;
            else if (taxable > 50000m) incometax = (taxable - 50000m) * 0.20m;
            else if (taxable > 250000) incometax = (taxable - 25000m) * 0.05m;
            decimal deductions = pf + proftax + incometax;
            decimal net = gross - deductions;
            Console.WriteLine("gross: " + gross);
            Console.WriteLine("Deductions: " + deductions);
            Console.WriteLine("Net: " + net);


        }
    }
}