using System;
using System.Diagnostics;
using System.Text;
namespace Day05
{
    class Comparing
    {
        static void Main()
        {
             var sw = new Stopwatch();
              sw.Start();
              string slow = "";
              for (int i = 0; i < 100000; i++)
                  slow += i + ",";
              sw.Stop();
              Console.WriteLine($"Concatenation: {sw.ElapsedMilliseconds} ms");

              sw.Reset();
              sw.Start();
               var sb = new StringBuilder();
              for (int i = 0; i < 100000; i++)
                  sb.Append(i).Append(',');
              string fast = sb.ToString();
              sw.Stop();
              Console.WriteLine($"Stringbuilder: {sw.ElapsedMilliseconds} ms");
            Console.WriteLine("heloo");
           



        }
    }
}