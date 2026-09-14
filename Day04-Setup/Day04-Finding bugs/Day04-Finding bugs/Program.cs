using System;
namespace Day04
{
    class FindingBugs
    {
        static void Main()
        {
            Console.WriteLine(SumRange(1,10));
            Console.WriteLine(Average(1,2));
            Console.WriteLine(Grade(90));
        }
        static int SumRange(int start,int end)
        {
            int total = 0;
            for (int i = start; i <= end; i++) // bug here = here the end is not included because we use i < end , so the correct format is i <= end.
                total += i;
            return total;

        }
        static double Average(params int[] numbers)
        {
            double sum = 0;                     // bug here = we used int it rounds up decimals so the correct format is using double data type .
            foreach (int n in numbers)
                sum += n;
            return sum / numbers.Length;
        }
        static string Grade (int score)

        {
            if (score >= 90) return "A";       // bug here = we used > that means it wont consider 90 , the correct format is >= 90 .
            if (score >= 80) return "B";
            if (score >= 70) return "C";
            return "F";
        }   
    }
}