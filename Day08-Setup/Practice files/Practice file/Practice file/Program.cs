using System;
using System.Collections.Generic;
List<string> names = new List<string>();
names.Add("Alice");
names.Add("Bob");
names.Add("Charlie");
names.AddRange(new[] { "David", "Eve" });
Console.WriteLine(names.Contains("Meera"));
var ages = new Dictionary<string, int>
{
    ["Asha"] = 24,
    ["Ravi"] = 31
};

ages.Add("Meera", 28);          // throws if the key already exists
ages["Sanjay"] = 45;            // adds, or overwrites silently
ages["Asha"] = 25;              // overwrite



Console.WriteLine(ages.ContainsKey("Meera"));
