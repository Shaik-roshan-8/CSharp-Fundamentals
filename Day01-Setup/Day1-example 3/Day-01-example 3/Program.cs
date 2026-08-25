using System;

namespace Day01
{
    class ArgsDemo
    {
        static int Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("usage: ArgsDemo Roshan");
                return 1;                      // non-zero = something went wrong
            }

            Console.WriteLine($"Arguments received: {args.Length}");
            for  (int i = 0; i <args.Length; i++)

            {
                Console.WriteLine($"  args[{i}] = {args[i]}");

            }

            Console.WriteLine($"Hello, {args[0]}!");
            return 0;                              // 0 = success
        }
    }
}