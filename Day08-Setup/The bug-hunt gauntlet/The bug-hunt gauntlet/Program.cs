using System;
namespace Day09
{
    class Program
    {
        public static void Main()
        {
            List<string> items = new List<string> { };
            Console.WriteLine(IsEmpty(items));

            int part = 25;
            int whole = 100;
            Console.WriteLine(PercentageOf(part, whole));

            string[] words = new string[5] { "roshan", "Bharath", "Reddy", "Noor", "Uday" };
            PrintAll(words);


            string fullname = "Roshan is an intermediate learner of CSharp.";
            Console.WriteLine(Initials(fullname));

            List<decimal> values = new List<decimal> { 12.3m, 13.43m, 45.33m, 22m, 22.56m };
            Console.WriteLine(Total(values));


            int n = 500;
            int m = 0;
            int o = -678;
            Console.WriteLine(CountDigits(n));
            Console.WriteLine(CountDigits(m)); // wrong count of digits .
            Console.WriteLine(CountDigits(o)); // negative symbol did not came under count .

        }
        static bool IsEmpty(List<string> items) => (items.Count) == 0;
        static double PercentageOf(int part, int whole) => ((double)part / (double)whole) * 100;
        static void PrintAll(string[] items)
        {
            for (int i = 0; i <= items.Length - 1; i++)
                Console.WriteLine(items[i]);
        }
        // Bug 4 — throws NullReferenceException, sometimes
        static string Initials(string fullName)
        {
            string[] parts = fullName.Split(' ');
            return $"{parts[0][0]}{parts[1][0]}";
        }
        // Bug 5 — the total is always the last value, not the sum
        static decimal Total(List<decimal> amounts)
        {
            decimal total = 0;
            foreach (decimal a in amounts) total += a;
            return total;
        }
        static int CountDigits(int n)
        {
            int count = 0;
            while (n != 0) { count++; n = n / 10; }
            return count;
        }
        // Infinite loop never happens .



    }
}