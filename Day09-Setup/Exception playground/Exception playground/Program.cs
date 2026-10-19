using System;
using System.Security.Cryptography.X509Certificates;
using System.Collections.Generic;
using System.IO;
namespace Day09
{
    class program
    {
        public static void Main()
        {
            TriggerDivedByZero();
            TriggerNullReferenceException(); // not able to catch this dont know why ??
            TriggerIndexOutOfRangeException();
            TriggerInvalidCastException();
            TriggerFormatException();
            TriggerOverflowException();
            TriggerArgumentOutOfRangeException();
            TriggerFileNotFoundException();

            // ⚠️ StackOverflowException cannot be caught in .NET,
            // so calling TriggerSTackOverFlowException() will crash the program.
           
            // TriggerSTackOverFlowException();

            TriggerDivedByZeroWIthNestedTry();

            // Demonstrate throw; vs throw ex;
            try
            {
                DemoThrow();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outer catch after throw;");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }

            try
            {
                DemoThrowEx();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Outer catch after throw ex;");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        
        static void TriggerDivedByZero()
        {
            try
            {
                int num1 = 105;
                int num2 = 0;

                int result = num1 / num2;
                Console.WriteLine(result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerNullReferenceException()
        {
            try
            {
                string name = null;
                Console.WriteLine(name.Length);
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("Can not perform action on null / empty string");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerIndexOutOfRangeException()
        {
            try
            {
                string[] words = new string[4] { "ww", "ee", "trtr", "wond" };
                Console.WriteLine(words[4]);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Trying to access the element which is not in range");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerInvalidCastException()
        {
            try
            {
                object obj = "Hello";
                int result = (int)obj;
            }
            catch (InvalidCastException ex)
            {
                Console.WriteLine("Cannot convert type object into int ");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerFormatException()
        {
            try
            {
                string number = "abcd";
                int parsed = int.Parse(number);
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Cannot convert to expected format");

                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerOverflowException()
        {
            try
            {
                int number = int.MaxValue;
                int checking = number + 1;
                Console.WriteLine(checking);
            }
            catch (OverflowException ex)
            {
                Console.WriteLine("Number requesting to print is above the limit of data type");

                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("StackTrace: " + ex.StackTrace);
            }
        }
        static void TriggerArgumentOutOfRangeException()
        {
            try
            {
                List<int> values = new List<int>(10);
                values.Insert(11, 25);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Trying to add items beyond the capacity of collection");

                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerFileNotFoundException()
        {
            try
            {
                File.ReadAllText("Nonexistingfile.txt");
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine("File does not exist");

                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");
            }
        }
        static void TriggerSTackOverFlowException()
        {
            try
            {
                static void recursive()
                {
                    Console.WriteLine("Im recusive with no base ");
                    recursive();
                }
            }
            catch (StackOverflowException ex)
            {
                Console.WriteLine("No base case");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");

            }
        }
        static void TriggerDivedByZeroWIthNestedTry()
        {
            try
            {
                int num1 = 105;
                int num2 = 0;

                int result = num1 / num2;
                Console.WriteLine(result);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Cannot divide by zero");
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");

                try
                {
                    List<int> values = new List<int>(17);
                    values.Insert(22, 25);
                }
                catch (ArgumentOutOfRangeException exe)
                {
                    Console.WriteLine("Trying to add items beyond the capacity of collection");

                    Console.WriteLine("Type: " + exe.GetType());
                    Console.WriteLine("Message: " + exe.Message);
                    Console.WriteLine("===========================================================================================================================================================");
                    Console.WriteLine("StackTrace: " + exe.StackTrace);
                    Console.WriteLine("===========================================================================================================================================================");
                }

            }




        }
        static void MethodA()
        {
            MethodB();
        }

        static void MethodB()
        {
            int x = 5;
            int y = 0;
            int result = x / y;   // crash here
        }
        static void DemoThrow()
        {
            try
            {
                MethodA();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");

                // Rethrow using bare throw
                throw;  // preserves original stack trace
            }
        }
        static void DemoThrowEx()
        {
            try
            {
                MethodA();
            }
            catch (DivideByZeroException ex)
            {

                Console.WriteLine("Type: " + ex.GetType());
                Console.WriteLine("Message: " + ex.Message);
                Console.WriteLine("===========================================================================================================================================================");
                Console.WriteLine("StackTrace: " + ex.StackTrace);
                Console.WriteLine("===========================================================================================================================================================");

                // Rethrow using throw ex (resets stack trace)
                throw ex;
            }


        }
    }

}