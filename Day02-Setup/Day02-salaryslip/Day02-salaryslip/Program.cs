using System;
using System.Diagnostics.CodeAnalysis;

namespace Day02
{
    class Salaryslip
    {
        static void Main()
        {

            
            decimal Basic; // double is binary floating point and have less precision than decimal.
            while (true)
            {
                Console.WriteLine("Enter your monthly basic salary");
                string? basicsalary = Console.ReadLine();

                if(!decimal.TryParse(basicsalary, out Basic))
                {
                    Console.WriteLine("Salary is not valid");
                    continue;

                }
                if (Basic<0)
                {
                    Console.WriteLine("salary is not valid ");
                    continue;

                }

                break;

            


            }

            decimal HRA = Basic * 0.40m;
            decimal Transportallowance = 1600m;
            decimal PFdeduction = Basic * 0.12m;
            decimal Professionaltax = 200m;

            decimal subtotal = HRA + Transportallowance + Basic;
            decimal Totaldeductions = PFdeduction + Professionaltax;
            decimal netpay = subtotal - Totaldeductions;


            Console.WriteLine("==================================================================================");
            Console.WriteLine("                               Salary slip");
            Console.WriteLine("==================================================================================");
            Console.WriteLine($"{"Basic salary",-13}= {Basic,-20:N2} {"PFdeduction",-16}= {PFdeduction,20:N2}");
            Console.WriteLine($"{"HRA",-13}= {HRA,-20:N2} {"Professionaltax",-16}= {Professionaltax,20:N2}");
            Console.WriteLine($"{"TA",-13}= {Transportallowance,-20:N2}"                                       );
            Console.WriteLine("==================================================================================");
            Console.WriteLine($"{"subtotal",-13}= {subtotal,-20:N2} {"Totaldeductions",-21}= {Totaldeductions,20:N2}");
            Console.WriteLine("====================================================================================");
            Console.WriteLine($"                           Netpay = {netpay:N2}");









            

            

            
        }
    }
}