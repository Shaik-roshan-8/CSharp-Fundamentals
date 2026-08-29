using System;

    namespace Day02
{
    class TypeExplorer
    {
        static void Main()
        {
            int number;
            byte numberbyte;
            short numbershort;
            long numberlong;
            float numberfloat;
            decimal numberdecimal;
            double numberdouble;
            bool numberbool;


            Console.WriteLine("===================================================================");
            Console.WriteLine($"| max of int:       {int.MaxValue,45}|");
            Console.WriteLine($"| min of int:       {int.MinValue,45}|");
            Console.WriteLine($"| max of byte:      {byte.MaxValue,45}|");
            Console.WriteLine($"| min of byte:      {byte.MinValue,45}|");
            Console.WriteLine($"| max of short:     {short.MaxValue,45}|");
            Console.WriteLine($"| min of short:     {short.MinValue,45 }|");
            Console.WriteLine($"| max of long:      {long.MaxValue,45}|");
            Console.WriteLine($"| min of long:      {long.MinValue,45}|");
            Console.WriteLine($"| max of float:     {float.MaxValue,45}|");
            Console.WriteLine($"| min of float:     {float.MinValue,45}|");
            Console.WriteLine($"| max of decimal:   {decimal.MaxValue,45}|");
            Console.WriteLine($"| min of decimal:   {decimal.MinValue,45}|");
            Console.WriteLine($"| max of double:    {double.MaxValue,45}|");
            Console.WriteLine($"| min of double:    {double.MinValue,45}|");
            Console.WriteLine($"| max of bool:      {bool.TrueString,45}|");
            Console.WriteLine($"| min of bool:      {bool.FalseString,45}|");

            Console.WriteLine($"| size of int:      {sizeof(int),39} bytes|");
            Console.WriteLine($"| size of byte:     {sizeof(byte),39} bytes|");
            Console.WriteLine($"| size of short:    {sizeof(short),39} bytes|");
            Console.WriteLine($"| size of long:     {sizeof(long),39} bytes|");
            Console.WriteLine($"| size of float:    {sizeof(float),39} bytes|");
            Console.WriteLine($"| size of decimal:  {sizeof(decimal),39} bytes|");
            Console.WriteLine($"| size of double:   {sizeof(double),39} bytes|");
            Console.WriteLine($"| size of bool:     {sizeof(bool),39} bytes|");

            Console.WriteLine("===================================================================");
             
               // add checked here to get overflow error
            {


                number = int.MaxValue;
                number++;
                Console.WriteLine($"number = {number}"); // acting like a circle if we add one number extra it will go back to the min value of int ( wrapping)

            }

        }
    }
}
