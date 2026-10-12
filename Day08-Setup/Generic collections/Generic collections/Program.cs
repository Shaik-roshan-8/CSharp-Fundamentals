using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
namespace Day08
{
    class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>(5);
            Console.WriteLine("Is empty: " + stack.IsEmpty()); // Output: Is empty: True
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            stack.Push(4);
            stack.Push(5);
            stack.Push(6); // This will trigger the resizing of the stack
            Console.WriteLine("Stack count: " + stack.Count); // Output: Stack count: 6
            Console.WriteLine("Top item: " + stack.Peek()); // Output: Top item: 6
            Console.WriteLine("Popped item: " + stack.Pop()); // Output: Popped item: 6
            Console.WriteLine("Stack count after pop: " + stack.Count); // Output: Stack count after pop: 5




            Collections findingmax = new Collections();

            // Call Max with int[]
            int[] numbers = { 1, 2, 3, 4, 5, 6, 6, 7, 8, 8, 8, 9 };
            int maxInt = findingmax.Max(numbers);
            Console.WriteLine("Max int: " + maxInt);



            List<Product> products = new List<Product>
            {
                new Product { Name = "Keyboard", Category = "Electronics" },
                new Product { Name = "Mouse", Category = "Electronics" },
                new Product { Name = "Apple", Category = "Fruit" },
                new Product { Name = "Banana", Category = "Fruit" },
                new Product { Name = "Shirt", Category = "Clothing" }
            };
            Dictionary<string, List<Product>> groupedProducts = CollectionsForGroupBy.GroupBy(products, p => p.Category);
            foreach (var kvp in groupedProducts)
            {
                Console.WriteLine($"Category: {kvp.Key}");
                foreach (var prod in kvp.Value)
                {
                    Console.WriteLine($" - {prod.Name}");
                }
            }
        }

        public class Stack<T>
        {
            private T[] items;
            private int counter;
            public Stack(int Size)
            {
                items = new T[Size];
                counter = 0;
            }
            public void Push(T value)
            {
                if (counter == items.Length)
                {
                    T[] newItems = new T[items.Length * 2];
                    Array.Copy(items, newItems, counter);
                    items = newItems;
                }
                items[counter] = value;
                counter++;
            }
            public T Pop()
            {
                if (counter == 0)
                {
                    throw new InvalidOperationException("Stack is empty");
                }
                counter--; // to make counter index and sets counter to total number of items in the stack
                return items[counter];

            }
            public T Peek()
            {
                if (counter == 0)
                {
                    throw new InvalidOperationException("Stack is empty");
                }
                return items[counter - 1]; // to make counter index 
            }
            public int Count
            {
                get { return counter; }
            }
            public bool IsEmpty()
            {
                return counter == 0;
            }

            // Writing generic methods





        }

    }
    class Collections
    {
        public T Max<T>(IEnumerable<T> source) where T : IComparable
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }
            List<T> list = new List<T>(source);
            T maximum = list[0];

            foreach (T item in source)
            {
                if (item.CompareTo(maximum) > 0)
                {
                    maximum = item;
                }
            }
            return maximum;
        }
        public void shuffle<T>(List<T> list)
        {
            if (list == null)
            {
                throw new ArgumentNullException(nameof(list));
            }
            Random random = new Random();
            for (int i = 0; i < list.Count - 1; i++) // here the last element is included in shuffle . if we dont use -1 the last element is swappped with itself.
            {
                int j = random.Next(i, list.Count); // here in second last iteration the last value and 2nd last value are swapped.last list.count is excluded
                T Temp = list[i];
                list[i] = list[j];
                list[j] = Temp;
            }
        }
    }
    class Product
    {
        public string Name { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
    public class CollectionsForGroupBy
    {
        public static Dictionary<Tkey, List<T>> GroupBy<T, Tkey>(IEnumerable<T> items, Func<T, Tkey>keySelector) where Tkey : notnull
        {
            Dictionary<Tkey, List<T>> result = new Dictionary<Tkey, List<T>>();

            foreach(var item in items)
            {
                Tkey key = keySelector(item);

                if(!result.ContainsKey(key))
                {
                    result[key] = new List<T>();
                }
                result[key].Add(item);

            }
            return result;
        }
    }

}