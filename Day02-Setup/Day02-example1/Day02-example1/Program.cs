using System;
namespace Day02
{
    struct pointstruct { public int X; public int Y;  } // value type
    class pointclass { public int X; public int Y; } // reference type

    class CopyDemo
    {
        static void Main()
        {
            //value type
            pointstruct a = new pointstruct { X = 1, Y = 1 };
            pointstruct b = a; // copy the value of a to b  
            b.X = 99;
            Console.WriteLine($" struct =a.X = {a.X} b.X={b.X}"); // a.X = 1, b.X = 1


            //reference type 
            pointclass c = new pointclass { X = 1, Y = 1 };
            pointclass d = c; // copy the reference of c to d
            d.X = 99;
           Console.WriteLine($" class =c.X = {c.X} d.X={d.X}"); // c.X = 99, d.X = 99

            //string
            string s1 = "hello";
            string s2 = s1; // copy the reference of s1 to s2
            s2=s2.ToUpper(); // s2 = "HELLO"
            Console.WriteLine($" string =s1 = {s1} s2={s2}"); // s1 = hello, s2 = HELLO

        }
    }

}
