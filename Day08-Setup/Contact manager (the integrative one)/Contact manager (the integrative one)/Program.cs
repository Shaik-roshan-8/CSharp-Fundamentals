using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
namespace Day08
{
    class Program
    {
        public static void Main()
        {
            ContactManager manager = new ContactManager();

            // Create 5 contacts
            Contact c1 = new Contact { Id = 1, Name = "Shaik", Phone = "9876543210", Email = "shaik@gmail.com", City = "Hyderabad", Tags = new HashSet<string> { "Friend", "Work" } };
            Contact c2 = new Contact { Id = 2, Name = "Ayesha", Phone = "9123456780", Email = "ayesha@gmail.com", City = "Dubai", Tags = new HashSet<string> { "Family" } };
            Contact c3 = new Contact { Id = 3, Name = "Imran", Phone = "9988776655", Email = "imran@gmail.com", City = "Delhi", Tags = new HashSet<string> { "Colleague" } };
            Contact c4 = new Contact { Id = 4, Name = "Zara", Phone = "9911223344", Email = "zara@gmail.com", City = "Mumbai", Tags = new HashSet<string> { "School", "Friend" } };
            Contact c5 = new Contact { Id = 5, Name = "Arjun", Phone = "9001122334", Email = "arjun@gmail.com", City = "Chennai", Tags = new HashSet<string> { "Gym" } };

            // Add them to the manager
            manager.Add(c1);
            manager.Add(c2);
            manager.Add(c3);
            manager.Add(c4);
            manager.Add(c5);

            // Now you can perform operations on manager:
            // manager.ListContacts();
            // manager.SortByName();
            // manager.SortByCity();
            // manager.SearchByName("Shaik");
            // manager.FilterByCity("Dubai");
            // manager.FilterByTag("Friend");
            // manager.DistinctCities();
            // manager.DistinctTags();
            // manager.Edit(1);
            // manager.Delete(2);
        }
    }

        
    
    class Contact : IComparable<Contact> // we implementing here because we need to sort contact object , which is complex type .
    {
        public int Id;
        public string Name;
        public string Phone;
        public string Email;
        public string City;
        public HashSet<string> Tags;

        public int CompareTo(Contact other) 
        {
            return string.Compare(this.Name, other.Name, StringComparison.OrdinalIgnoreCase);
        }
    }
    class ContactManager
    {
        List<Contact> Contacts = new List<Contact>();
        Dictionary<int,Contact> Details = new Dictionary<int, Contact>();
        HashSet<string> Emails = new HashSet<string>();


        public void Add(Contact contact)
        {
            if(Emails.Contains(contact.Email))
            {
                Console.WriteLine("Email already exist");
                return;
            }
            Contacts.Add(contact);
            Details.Add(contact.Id, contact);
            Emails.Add(contact.Email);
        }
        public void Delete(int Id)
        {
            if (Details.TryGetValue(Id, out Contact c))
            {
                Details.Remove(Id);
                Contacts.Remove(c);
            }
            else Console.WriteLine("Id not found");

        }
        public void Edit(int Id)
        {
            if (!Details.TryGetValue(Id, out Contact contact))
            {
                Console.WriteLine(" key not found");
                return;
            }
            Console.WriteLine("What do you want to edit?");
            Console.WriteLine("1. Name");
            Console.WriteLine("2. City");
            Console.WriteLine("3. Email");
            Console.WriteLine("4. Phone");

            string choice = Console.ReadLine();
            int.TryParse(choice, out int cchoice);

            switch (cchoice)
            {
                case 1:
                    Console.WriteLine("Enter new name ");
                    string newname = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newname))
                        contact.Name = newname;
                    else
                        Console.WriteLine("Invalid name ");
                    break;
                case 2:
                    Console.Write("Enter new city: ");
                    string newCity = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(newCity))
                        contact.City = newCity;
                    else
                        Console.WriteLine("Invalid city.");
                    break;


                case 3:
                    Console.Write("Enter new email: ");
                    string newEmail = Console.ReadLine();
                    if (!IsValidEmail(newEmail))
                    {
                        Console.WriteLine("Invalid email format.");
                    }
                    else if(Emails.Contains(newEmail))
                    {
                        Console.WriteLine("Duplicate email ");
                    }
                    else
                    {
                        contact.Email = newEmail;
                        Emails.Remove(contact.Email);
                        Emails.Add(newEmail);
                    }
                    break;
                    

                case 4:
                    Console.Write("Enter new phone: ");
                    string newPhone = Console.ReadLine();
                    if (IsValidPhone(newPhone))
                        contact.Phone = newPhone;
                    else
                        Console.WriteLine("Invalid phone format.");
                    break;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            
            }

        }
        // helper methods 
        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }

        private bool IsValidPhone(string phone)
        {
            return phone.All(char.IsDigit) && phone.Length >= 7;
        }
        // helper method ends 

        public void ListContacts()
        {
            foreach ( var kvp in Details)
            {
                Console.WriteLine($"{kvp.Key} -  {kvp.Value.Name}, {kvp.Value.Email}, {kvp.Value.City}");
                Console.WriteLine("Tags: " + string.Join(", ", kvp.Value.Tags));
                Console.WriteLine("-----------------------------");
               
            }
        }
        public void SearchByName(string substring)
        {
            foreach(var contact in Contacts)
            {
                if (contact.Name.Contains(substring, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }
                    
            }
        }
        public void FilterByCity(string city)
        {
            foreach(var contact in Contacts)
            {
                if(contact.City.Equals(city))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }
                    
            }
        }
        public void FilterByTag(string tag)
        {
            foreach(var contact in Contacts)
            {
                if(contact.Tags.Contains(tag))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }
            }
        }
        public  void DistinctCities()
        {
            HashSet<string> distinctCities = new HashSet<string>();
            foreach (var contact in Contacts)
            {
                distinctCities.Add(contact.City);
            }
            foreach (var city in distinctCities)
            {
                Console.WriteLine(city);
            }
        }
        public void DistinctTags()
        {
            HashSet<string> distinctTags = new HashSet<string>();
            foreach(var contact in Contacts)
            {
                foreach(var tag in contact.Tags)
                {
                    distinctTags.Add(tag);
                }
            }
            foreach (var tag in distinctTags)
            {
                Console.WriteLine(tag);
                
            }
            Console.WriteLine($"count of tags - {distinctTags.Count}");
        }
        public void SortByName()
        {
            Contacts.Sort();
            Console.WriteLine("Sorted by name");
            foreach(var c in Contacts)
            {
                Console.WriteLine($"{c.Name} - {c.City}");
            }
        }
        public void SortByCity()
        {
            Contacts.Sort((s1, s2) => string.Compare(s1.City, s2.City, StringComparison.OrdinalIgnoreCase));
        }


        

    }

}