using System;

namespace reciept
{
    class receipt
    {
        static void Main(string[] args)
        {
            string item1 = "fridge";
            decimal itemPrice1 = 30000m;
            int quantityof1 = 2;

            string item2 = "Washing Machine";
            decimal itemPrice2   = 25000m;
            int quantityof2 = 5;


            string item3 = "Air conditioner";
            decimal itemPrice3 = 50000m;
            int quantityof3 = 3;


            decimal totalPriceof1 = itemPrice1 * quantityof1;
            decimal totalPriceof2 = itemPrice2 * quantityof2;
            decimal totalPriceof3 = itemPrice3 * quantityof3;

            Console.WriteLine("\nReceipt:");
            Console.WriteLine($"Item: {item1}");
            Console.WriteLine($"Price: {itemPrice1:C}");
            Console.WriteLine($"Quantity: {quantityof1}");
            Console.WriteLine($"Total: {totalPriceof1:C}");
            Console.WriteLine($"Item: {item2}");
            Console.WriteLine($"Price: {itemPrice2:C}");
            Console.WriteLine($"Quantity: {quantityof2}");
            Console.WriteLine($"Total: {totalPriceof2:C}");
            Console.WriteLine($"Item: {item3}");
            Console.WriteLine($"Price: {itemPrice3:C}");
            Console.WriteLine($"Quantity: {quantityof3}");
            Console.WriteLine($"Total: {totalPriceof3:C}");

            Console.WriteLine($"Grand total : {(totalPriceof1 + totalPriceof2 + totalPriceof3):C}");
        }
    }
}