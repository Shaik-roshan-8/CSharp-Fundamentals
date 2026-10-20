using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
namespace Day08
{
    class Program
    {
        public static void Main()
        {
            ContactManager manager = new ContactManager("C:\\Users\\ganvitraders_roshan\\C-sharp Projects\\Contacts");

            try
            {
                manager.Load();
            }
            catch (ContactStoreException ex)
            {
                Console.WriteLine($"Error loading contacts: {ex.Message}");
            }

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


            try
            {
                manager.Save();
            }
            catch (ContactStoreException ex)
            {
                Console.WriteLine($"Error saving contacts: {ex.Message}");
            }
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
        public string ToCsv()
        {
            return $"{Id},{Name},{Phone},{Email},{City},{string.Join('|', Tags)}";
        }
        public static Contact FromCsv(string line , int linenumber , out bool success)
        {

            success = true;
            try
            {
                var parts = line.Split(',');
                if(parts.Length<5)
                {
                    success = false;
                    return  null;
                }
                Contact c = new Contact
                {
                    Id = int.Parse(parts[0]),
                    Name = parts[1],
                    Phone = parts[2],
                    Email = parts[3],
                    City = parts[4],
                    Tags = parts.Length > 5 ? new HashSet<string>(parts[5].Split('|')) : new HashSet<string>()
                };
                return c;
            }
            catch(Exception)
            {
                success = false;
                return null;
            }
        }
    }
    class ContactManager
    {
        List<Contact> Contacts = new List<Contact>();
        Dictionary<int, Contact> Details = new Dictionary<int, Contact>();
        HashSet<string> Emails = new HashSet<string>();
        private string filePath; // extra


        public ContactManager(string filepath) // extra feature
        {
            this.filePath = filepath;
        }
        public bool HasContacts() => Contacts.Count > 0;

        public void Save()
        {
            string tempFile = filePath + "tmp.csv";
            try
            {
                using StreamWriter writer = new StreamWriter(tempFile);
                {
                    foreach(var c in Contacts)
                    {
                        writer.WriteLine(c.ToCsv());
                    }
                }
                if (File.Exists(filePath)) File.Delete(filePath);
                File.Move(tempFile, filePath);
            }
            catch (IOException ex)
            {
                throw new ContactStoreException("Failed to save contacts", ex);
            }
        }
        public void Load()
        {
            if (!File.Exists(filePath)) return;
            List<int> badLines = new List<int>();
            try
            {
                using (var reader = new StreamReader(filePath))
                {
                    string line;
                    int lineNumber = 1;
                    while ((line = reader.ReadLine()) != null)
                    {
                        var contact = Contact.FromCsv(line, lineNumber, out bool success);
                        if (success)
                        {
                            Add(contact);
                        }
                        else
                        {
                            badLines.Add(lineNumber);
                        }
                        lineNumber++;
                    }


                }
                if (badLines.Count > 0)
                {
                    Console.WriteLine("Malformed lines at: " + string.Join(", ", badLines));
                }

            }
            catch (IOException ex)
            {
                throw new ContactStoreException("Failed to load contacts", ex);
            }
        }

        public void Add(Contact contact)
        {
            if (Emails.Contains(contact.Email))
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
                    else if (Emails.Contains(newEmail))
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
            foreach (var kvp in Details)
            {
                Console.WriteLine($"{kvp.Key} -  {kvp.Value.Name}, {kvp.Value.Email}, {kvp.Value.City}");
                Console.WriteLine("Tags: " + string.Join(", ", kvp.Value.Tags));
                Console.WriteLine("-----------------------------");

            }
        }
        public void SearchByName(string substring)
        {
            foreach (var contact in Contacts)
            {
                if (contact.Name.Contains(substring, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }

            }
        }
        public void FilterByCity(string city)
        {
            foreach (var contact in Contacts)
            {
                if (contact.City.Equals(city))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }

            }
        }
        public void FilterByTag(string tag)
        {
            foreach (var contact in Contacts)
            {
                if (contact.Tags.Contains(tag))
                {
                    Console.WriteLine($"Id: {contact.Id}, Name: {contact.Name}, Email: {contact.Email}, City: {contact.City}");
                }
            }
        }
        public void DistinctCities()
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
            foreach (var contact in Contacts)
            {
                foreach (var tag in contact.Tags)
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
            foreach (var c in Contacts)
            {
                Console.WriteLine($"{c.Name} - {c.City}");
            }
        }
        public void SortByCity()
        {
            Contacts.Sort((s1, s2) => string.Compare(s1.City, s2.City, StringComparison.OrdinalIgnoreCase));
        }




    }
    class ContactStoreException : Exception
    {
        public ContactStoreException(string message, Exception inner) : base(message, inner) { }
    }

}