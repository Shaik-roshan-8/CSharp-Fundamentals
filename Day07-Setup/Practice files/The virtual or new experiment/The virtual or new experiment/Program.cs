using System;
namespace Dayo7
{
    class Program
    {
        public static void Main()
        {
            Baseclass obj1 = new Baseclass();
            Derivedclass obj2 = new Derivedclass();
            Baseclass obj3 = new Derivedclass();
            Baseclass obj4 = new MoreDerivedclass();
            MoreDerivedclass obj5 = new MoreDerivedclass();
            Derivedclass obj6 = new MoreDerivedclass();
            Baseclass obj7 = new MoreDerivedclass();


            obj1.Display();  // Output: Base class Display method // because display method is virtual and obj1 is of type Baseclass
            obj2.Display();  // Output: Derived class Display method // because display method is virtual and obj2 is object of Derivedclass
            obj3.Display();  // Output: Derived class Display method // because display method is virtual and obj3 is object of Derivedclass
            obj4.Display();  // Output: More Derived class Display method // because display method is virtual and obj4 is object of MoreDerivedclass
            obj5.Display();  // Output: More Derived class Display method // because display method is virtual and obj5 is object of MoreDerivedclass
            obj6.Display();  // Output: More Derived class Display method // because display method is virtual and obj6 is object of MoreDerivedclass
            obj7.Display();  // Output: More Derived class Display method // because display method is virtual and obj7 is object of MoreDerivedclass



            obj1.Show();  // Output: Base class Show method // because show method is not virtual and obj1 is type Baseclass
            obj2.Show();  // Output: Derived class Show method // because show method is new and obj2 is type of Derivedclass
            obj3.Show();  // Output: Base class Show method // because show method is not virtual and obj3 is type of Baseclass
            obj4.Show();  // Output: Base class Show method // because show method is new and obj4 is type of MoreDerivedclass
            obj5.Show();  // Output: More Derived class Show method // because show method is new and obj5 is type of MoreDerivedclass
            obj6.Show();  // Output: Derived class Show method // because show method is new and obj6 is type of MoreDerivedclass
            obj7.Show();  // Output: Base class Show method // because show method is new and obj7 is type of MoreDerivedclass
        }
    }
    class Baseclass
    {
        public virtual void Display()
        {
            Console.WriteLine("Base class Display method");
        }
        public void Show()
        {
            Console.WriteLine("Base class Show method");
        }
    }
    class Derivedclass : Baseclass
    {
        public override void Display()
        {
            Console.WriteLine("Derived class Display method");
        }
        public new void Show()
        {
            Console.WriteLine("Derived class Show method");
        }
    }
    class MoreDerivedclass : Derivedclass
    {
        public override void Display()
        {
            Console.WriteLine("More Derived class Display method");
        }
        public new void Show()
        {
            Console.WriteLine("More Derived class Show method");
        }
    }
}