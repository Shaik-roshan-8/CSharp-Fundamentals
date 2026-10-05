using System;
using System.Security.Cryptography.X509Certificates;
namespace Day07
{
    class Program
    {
        static void Main()
        {
            Employee e1 = new SalariedEmployee { Name = "Shaik", Id = "101", AnnualSalary = 1200000 };
            Employee e2 = new HourlyEmployee { Name = "Ali", Id = "102", Rate = 500, HoursWorked = 170 };
            Employee e3 = new CommissionEmployee { Name = "Sara", Id = "103", BaseSalary = 20000, SalesAmount = 500000, CommissionRate = 0.10m };
            Employee e4 = new SalariedEmployee { Name = "Shaik Duplicate", Id = "101", AnnualSalary = 1200000 };

            Employee[] Employess = new Employee[] { e1, e2, e3 };

            foreach(Employee emp in Employess)
            {
                Console.WriteLine(emp.ToString());
                Console.WriteLine($"Monthly Pay: {emp.CaluclateMonthlyPay()}");

                if (emp is IBonusEligible bonusEmp)
                {
                    Console.WriteLine($"Bonus = {bonusEmp.CalculateBonus()}");
                }
            }
            var set = new HashSet<Employee>();
            set.Add(e4);
            set.Add(e1);
            set.Add(e2);
            set.Add(e3);
            Console.WriteLine($"HashSet count (should be 3): {set.Count}");
            
            // just parcticing block 
            Console.WriteLine(e1.GetHashCode());
            if(e1.Equals(e4))
            {
                Console.Write("it is equal");
            }
            // practice ends


        }
    }
    public abstract class Employee
    {
        public string? Name { get; set; }
        public string? Id { get; set; }

        public abstract decimal CaluclateMonthlyPay();

        public override string ToString()
        {
            return $"EmployeeId = {Id} and Name = {Name}";
        }
        public override bool Equals(object? obj)
        {
            if(obj is Employee other)
            {
                return this.Id == other.Id;
            }
            return false;
        }
        public override int GetHashCode()
        {
                return Id?.GetHashCode() ?? 0;
        }
    }
    class SalariedEmployee : Employee, IBonusEligible
    {
        decimal monthlysalary;
        public decimal AnnualSalary { get; set; }

        public override decimal CaluclateMonthlyPay()
        {
            monthlysalary = AnnualSalary / 12;
            return monthlysalary;
        }
        public decimal CalculateBonus()
        {
            return monthlysalary * 0.10m;
        }

    }
    class HourlyEmployee : Employee
    {

        public decimal Rate { get; set; }
        public int HoursWorked { get; set; }

        public override decimal CaluclateMonthlyPay()
        {
            if (HoursWorked < 160)
            {
                return Rate * HoursWorked;
            }
            else
            {
                return Rate * 160 + ((HoursWorked - 160) * Rate * 1.5m);
            }

        }

    }
    class CommissionEmployee : Employee
    {
        decimal monthlysalary;
        public decimal BaseSalary { get; set; }
        public decimal SalesAmount { get; set; }
        public decimal CommissionRate { get; set; }

        public override decimal CaluclateMonthlyPay()
        {
            return BaseSalary + (SalesAmount * CommissionRate);
        }
        public decimal CalculateBonus()
        {
            return SalesAmount * 0.05m;
        }
    }
    interface IBonusEligible
    {
        decimal CalculateBonus();
    }


}