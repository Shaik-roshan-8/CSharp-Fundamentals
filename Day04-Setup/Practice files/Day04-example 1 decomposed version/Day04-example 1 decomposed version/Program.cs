using System;
namespace day04
{
    class ExampledeComposed
    {
        static void Main()
        {
            decimal basic = ReadMoney("Enter basic salary:");

            decimal gross = CalculateGross(basic);
            decimal deductions =CalculateDeductions(basic,gross);
            decimal net = gross - deductions;

            PrintPayslip(basic, gross, deductions, net);

        }
        static decimal CalculateGross(decimal basic)
          =>  basic + CalculateHra(basic) + TransportAllowance;
        static decimal CalculateHra(decimal basic)
            => basic * HraRate;
        static decimal CalculateDeductions(decimal basic, decimal gross)
            => CalculatePf(basic) + ProfessionalTax + CalculateIncomeTax( gross - CalculatePf(basic));
        static decimal CalculatePf(decimal basic)
            => basic * PfRate;
        static decimal CalculateIncomeTax(decimal taxable)
            => taxable switch
            {
                > 100000m => (taxable - 100000m) * 0.30m,
                > 50000m => (taxable - 50000m) * 0.20m,
                > 25000m => (taxable - 25000m) * 0.05m,
                _ => 0m
            };
        static decimal ReadMoney (string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                if (decimal.TryParse(Console.ReadLine(), out decimal value) && value >= 0)
                    return value;
                Console.WriteLine("Please enter a non negative amount.");

            }

            }
        static void PrintPayslip(decimal basic, decimal gross, decimal deductions, decimal net)
        {
            Console.WriteLine(new string('-', 34));
            Console.WriteLine($"{"Basic",-20}{basic,14:N2}");
            Console.WriteLine($"{"Gross",-20}{gross,14:N2}");
            Console.WriteLine($"{"Deductions",-20}{deductions,14:N2}");
            Console.WriteLine(new string('-', 34));
            Console.WriteLine($"{"NET PAY",-20}{net,14:N2}");

        }
        const decimal HraRate = 0.40m;
        const decimal PfRate = 0.12m;
        const decimal TransportAllowance = 1600m;
        const decimal ProfessionalTax = 200m;



    }
}