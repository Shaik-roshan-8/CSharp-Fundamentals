using System;
using System.Diagnostics;
namespace Day06
{
    class Product
    {
        public string SKU { get; }
        public string Name { get; set; }
        private double _Unitprice;
        public double Unitprice
        {
            get
            { return _Unitprice; }
            set
            {
                if (value < 0)
                {
                    _Unitprice = 0;
                }
                else
                {
                    _Unitprice = value;
                }
            }
        }
        public int QuantityINStock { get; private set; }
        public int ReorderLevel { get; set; }
        private static double totalvalue = 0;

        public static double TotalValue
        {
            get { return totalvalue; }
        }
        public double StockValue
        {
            get
            {
                return Unitprice * QuantityINStock;
            }
        }
        public bool NeedsReorder
        {
            get
            {
                if (QuantityINStock <= ReorderLevel)
                {
                    return true;
                }
                return false;

            }
        }
        public void RecieveQty(int quantity)
        {
            if (quantity < 0)
            {
                Console.WriteLine($"Quantity cannot be negative{quantity}");
            }
            else
            {
                QuantityINStock += quantity;
                totalvalue += quantity * Unitprice;
            }
        }
        public bool TryIssue(int quantity, out string reason)
        {
            if (quantity < 0)
            {
                reason = $"Quantity cannot be negative : {quantity}";
                Console.WriteLine(reason);
                return false;
            }
            else if (quantity > QuantityINStock)
            {
                reason = $"Out of stock ";
                return false;
            }
            else
            {
                reason = "OK";
                QuantityINStock -= quantity;
                return true;
                
            }
            

        }
        public Product(string sku, string name, double unitPrice, int reorderLevel)
        {
            SKU = sku;
            Name = name;
            Unitprice = unitPrice;
            ReorderLevel = reorderLevel;
        }

    }
    class Program
    {
        static void Main()
        {
            Product widget = new Product("SKU001", "Widget", 25.00, 10);

            widget.RecieveQty(50);
            Console.WriteLine($"{widget.Name}: Qty={widget.QuantityINStock}, StockValue={widget.StockValue}");

            bool success = widget.TryIssue(20, out string reason); // doubt here why we mentioned reason again
            Console.WriteLine($"Issue 20 -> success={success}, reason={reason}, remaining={widget.QuantityINStock}");

            success = widget.TryIssue(1000, out reason);
            Console.WriteLine($"Issue 1000 -> success={success}, reason={reason}, remaining={widget.QuantityINStock}");

            widget.Unitprice = -50;
            Console.WriteLine($"After negative price attempt, Unitprice={widget.Unitprice}"); // trying to update negative value

            // widget.QuantityINStock = 9999;          trying to access private field from outside 

            Console.WriteLine($"NeedsReorder: {widget.NeedsReorder}");
            Console.WriteLine($"Total inventory value across all products: {Product.TotalValue}");


        }
    }
}