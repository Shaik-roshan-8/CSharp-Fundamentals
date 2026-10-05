using System;
using System.Runtime.CompilerServices;
namespace Day07
{
    class Program
    {
        static void Main()
        {
            BaseClass b = new BaseClass();
            b.Display(); // Output: BaseClass Display method
            b.Show();    // Output: BaseClass Show method
            DerivedClass d = new DerivedClass();
            d.Display(); // Output: DerivedClass Display method
            d.Show();    // Output: DerivedClass Show method

            // Twist here 

            BaseClass bd = new DerivedClass();
            bd.Display(); // Output: DerivedClass Display method
            bd.Show();    // Output: BaseClass Show method

            //override sticks to object and new sticks to variable type .
        }
    }
    public class BaseClass
    {
        public virtual void Display()
        {
            Console.WriteLine("BaseClass Display method");
        }

        public void Show()
        {
            Console.WriteLine("BaseClass Show method");
        }
    }
    public class DerivedClass : BaseClass
    {
        public override void Display()
        {
            Console.WriteLine("DerivedClass Display method");
        }
        public new void Show()
        {
            Console.WriteLine("DerivedClass Show method");
        }
    }

}