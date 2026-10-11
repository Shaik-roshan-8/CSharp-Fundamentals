using System;
using System.Collections.Generic;
using System.Linq;
namespace Day08
{
    public interface IEntity
    {
        int Id { get; set; }
    }
    public class Repository<T> where T : class, IEntity
    {
        public readonly Dictionary<int, T> _store = new Dictionary<int, T>();
        private int _nextId = 1;
        public int Count => _store.Count;
        public T Add(T entity)
        { 
            entity.Id = _nextId++;
            _store[entity.Id] = entity;
            return entity;
        }
        public bool TryGet(int id, out T? entity)
            => _store.TryGetValue(id, out entity);

        public bool Remove(int id)
            => _store.Remove(id);

        public IEnumerable<T> All()
            => _store.Values.ToList();

        public IEnumerable<T> Where(Func<T, bool> predicate)
            => _store.Values.Where(predicate).ToList();


    }
    public class Product : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
        public override string ToString()
       => $"{Id,4} {Name,-20} {Price,10:N2}";
    }
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? City { get; set; }
        public override string ToString()
            => $"{Id,4} {Name,-20} {City}";
    }
    class Program
    {
        static void Main()
        {
            var products = new Repository<Product>();
            var customers = new Repository<Customer>();

            products.Add(new Product { Name = "Keyboard", Price = 1799m });
            products.Add(new Product { Name = "Monitor", Price = 12499m });
            products.Add(new Product { Name = "Mouse", Price = 649m });

            customers.Add(new Customer { Name = "Asha Pandey", City = "Bengaluru" });
            customers.Add(new Customer { Name = "Ravi Kumar", City = "Pune" });

            Console.WriteLine("--- all products ---");
            foreach (var p in products.All()) Console.WriteLine(p);

            Console.WriteLine("--- products over 1000 ---");
            foreach (var p in products.Where(p => p.Price > 1000m)) Console.WriteLine(p);

            if (products.TryGet(2, out Product? found))
                Console.WriteLine($"Found: {found?.Name}");

            Console.WriteLine($"{products.Count} products, {customers.Count} customers");




        }
    }
}