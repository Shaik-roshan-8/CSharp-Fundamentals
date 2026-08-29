using System;

namespace Day02
{
    struct Pointstruct {public int x; public int y; }
    class Pointclass { public int x; public int y; }

    class Copyvsshare
    {
        static void Main()
        {
            Pointstruct a = new Pointstruct { x = 1, y = 1 };
            Pointstruct b = a;
            b.x = 99;                                               // x of b changed to 99

            Console.WriteLine($" struct values == a.x = {a.x} , b.x = {b.x}");


            Pointclass c = new Pointclass { x = 1,y = 1 };
            Pointclass d = c;
            d.x = 99;                                              // x of d changed to 99              

            Console.WriteLine($"class values == c.x = {c.x} , d.x = {d.x}");

            string s1 = "hello";
            string s2 = s1;
            s2 = s2.ToUpper();

            Console.WriteLine($"string values s1 = {s1}, s2 = {s2}");


            int[] e = { 1, 2, };
            int[] f = e;
            f[0] = 99;

            Console.WriteLine($"array values e[0] = {e[0]},f[0] = {f[0]}"); /* we created array e and f and the f is holdind reference of e because array is reference type
                                                                             if we change the value through the 2nd variable the original changes too
                                                                             because both are pointing to same object.*/
                                                                                // not changing value in variable 2 , changing value through variable 2 for same object.




        }
    }
}