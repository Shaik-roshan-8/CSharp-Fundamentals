using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
namespace Collection_playground
{
    class Program
    {
        public static void Main()
        {
            Collections demo = new Collections();
            demo.ListExample();
            demo.DictionaryExample();
            demo.HashsetExample();
            demo.QueueExample();
            demo.StackExample();
        }
    }
    class Collections
    {

        public void ListExample()
        {
            List<string> Tasks = new List<string>();
            // Adding and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Tasks.Add("Wake up");
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]}, count = {Tasks.Count}");
            Console.WriteLine("-------------------------------------------------------------");
            Tasks.Add("Eat breakfast");
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]} count = {Tasks.Count}");
            Console.WriteLine("-------------------------------------------------------------");
            Tasks.Insert(1, "Go to work");
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]} count = {Tasks.Count}");
            Console.WriteLine("-------------------------------------------------------------");
            Console.WriteLine("List of tasks:");
            // checking status using foreach loop
            Console.WriteLine("-------------------------------------------------------------");
            foreach (var task in Tasks)
            {
                Console.WriteLine(task);
            }
            // Removing and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Tasks.Remove("Eat breakfast");
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]} count = {Tasks.Count}");
            Tasks.RemoveAt(0);
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]} count = {Tasks.Count}");
            Tasks.RemoveRange(0, 1);
            for (int i = 0; i < Tasks.Count; i++)
                Console.WriteLine($"{Tasks[i]} count = {Tasks.Count}");

            // main problem it solves it can grow and shrink

        }
        public void DictionaryExample()
        {
            Dictionary<string, string> Countries = new Dictionary<string, string>();
            // Adding keyvaluepairs and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Countries.Add("USA", "Washington D.C.");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");

            Countries.Add("CN", "Ottawa");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");


            Countries.Add("MX", "Mexico City");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");


            Console.WriteLine("Dictionary of countries:");
            foreach (var country in Countries)
            {
                Console.WriteLine($"Country: {country.Key}, Capital: {country.Value}");
            }
            // Removing and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Countries.Remove("CN");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");
            Countries.Remove("MX");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");
            Countries.Remove("USA");
            foreach (KeyValuePair<string, string> kvp in Countries)
            {
                Console.WriteLine($"{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"{Countries.Count} countries in the dictionary.");

            // main problem it solves is store in keyvalue pairs and can grow and shrink
        }

        public void HashsetExample()
        {
            HashSet<string> Emails = new HashSet<string>();
            string[] DuplicatedEmails = new string[] { "roshan@gmail.com", "krishna@gmail.com", "Yadav@gmail.com", "bharath@gmail.com", "bharath@gmail.com" };
            // here in this array there are duplicates .
            Console.WriteLine("-------------------------------------------------------------");
            Emails = DuplicatedEmails.ToHashSet();
            Console.WriteLine("-------------------------------------------------------------");


            // Adding and checking status
            Emails.Add("john@example.com");
            foreach (var email in Emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine($"{Emails.Count} emails in the hashset.");
            Emails.Add("jane@example.com");
            foreach (var email in Emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine($"{Emails.Count} emails in the hashset.");
            // Adding duplicate email and checking status.
            Emails.Add("jane@example.com");
            foreach (var email in Emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine($"{Emails.Count} emails in the hashset.");


            Emails.Add("bob@example.com");
            foreach (var email in Emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine($"{Emails.Count} emails in the hashset.");
            // Adding duplicate emails collection  and checking status.


            // Removing and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Emails.Remove("john@example.com");

            foreach (var email in Emails)
            {
                Console.WriteLine(email);
            }
            Console.WriteLine($"{Emails.Count} emails in the hashset.");
        }

        // here we removed the duplicates and got unique items only inside a collection 

        public void QueueExample()
        {
            Queue<string> Jobs = new Queue<string>();

            //  adding the items to the queue and printing status
            Console.WriteLine("-------------------------------------------------------------");
            Jobs.Enqueue("C# developer");
            for (int i = 1; i < Jobs.Count; i++)
            {
                Console.WriteLine($"{Jobs}, {Jobs.Count}");
            }
            Jobs.Enqueue("Data Analyst");
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
            Jobs.Enqueue("Cloud Engineer");
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
            Jobs.Enqueue("Research Analyst");
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");

            // removing and printing status
            Console.WriteLine("-------------------------------------------------------------");
            Jobs.Dequeue();
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
            Jobs.Dequeue();
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
            Jobs.Dequeue();
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
            Jobs.Dequeue();
            foreach (string job in Jobs)
                Console.WriteLine($"{job},count = {Jobs.Count}");
        }
        public void StackExample()
        {
            Stack<string> Operations = new Stack<string>();

            // adding operations to stack and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Operations.Push("Download browser");
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Push("Open browser");
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Push("Open youtube");
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Push("Search for songs");
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }

            // Removing one by one and checking status
            Console.WriteLine("-------------------------------------------------------------");
            Operations.Pop();
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Pop();
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Pop();
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }
            Operations.Pop();
            foreach (string operation in Operations)
            {
                Console.WriteLine($"{operation} and the count is {Operations.Count}");
            }

        }

  




    }
    class Navigation
    {

        Stack<string> ForwardStack = new Stack<string>();
        Stack<string> BackwardStack = new Stack<string>();
        string? Currentpage = "Google";

        public void Youtube()
        {
            BackwardStack.Push(Currentpage);
            ForwardStack.Clear();
            Currentpage = "Youtube";

        }
        public void Facebook()
        {
            BackwardStack.Push(Currentpage);
            Currentpage = "Facebook";


        }
        public void Back()
        {
            ForwardStack.Push(Currentpage);
            Currentpage = BackwardStack.Pop();

        }
        public void Forward()
        {
            Currentpage = ForwardStack.Pop();
            BackwardStack.Push(Currentpage);
        }
        public void newpage(string page) // if wer navigate to new page the forward stack will be cleared and the current page will be added to backward stack
        {
            BackwardStack.Push(Currentpage);
            Currentpage = page;
            ForwardStack.Clear();
        } // My learning : if we want to store history like a realbrowser we have to create a list and add the pages from forward stack and backward stack to the list and then we can navigate to the pages in the list using index.
    }



}