using System;
namespace Day04
{
    class SampleClass
    {
        public int Number;
    }
    class Program
    {
        static void Main()
        {
            // create 1st object
            SampleClass obj1 = new SampleClass();
            obj1.Number = 10;
            Console.WriteLine($"obj1.Number before change = { obj1.Number}");

            // passing to method that modifies field
            ModifyField(obj1);
            Console.WriteLine($"obj1.number after ModifyField = {obj1.Number}");

            //creating 2nd object

            SampleClass obj2 = new SampleClass();
            obj2.Number = 20;
            Console.WriteLine($"obj2.Number before change = {obj2.Number}");

            // passing to method that reassigns parameter

            ReassignObject(obj2);
            Console.WriteLine($"obj2.number afer ReassignObject = {obj2.Number}");
        }
        static void ModifyField(SampleClass obj)
        {
            obj.Number = 100;
            Console.WriteLine($"Inside ModifyField , obj.Number = {obj.Number}");
        }
        static void ReassignObject(SampleClass obj)
        {
            obj = new SampleClass();
            obj.Number = 200;
            Console.WriteLine($"Inside ReassignObject , obj.Number ={obj.Number}");
        }

        // here we passed a value but it effects the object because we copy the reference not the value.

         /// here in first case we modified the property that changes the object and in 2nd case we reassigned the parameter so it created a new object and our old object remained same .
    }
}