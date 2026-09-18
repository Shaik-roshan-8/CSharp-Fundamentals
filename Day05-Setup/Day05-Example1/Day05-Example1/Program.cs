using System;
using System.Runtime.InteropServices;
using System.Text;
namespace Day05
{
    class CsvParser
    {
        static void Main()
        {
            string[] lines =
            {
                "Asha , Bengaluru , 24",
                "Ravi , Pune , 31",
                "Meera , Kochi , 28",
                "Broken,Line",                          // malformed 
                "Sanjay , Delhi , notanumber"           // malformed
            };

            Console.WriteLine($"{"NAME",-12}{"CITY",-14}{"AGE",5}");
            Console.WriteLine(new string('-',31));

            int valid = 0;
            var problems = new StringBuilder();

            foreach ( string line in lines )
            {
                string[] parts = line.Split(',',
                    StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries );

                if ( parts.Length != 3 )
                {
                    problems.AppendLine( $"Wrong field count : \"{ line}\"" );
                    continue;
                }

                if (!int.TryParse(parts[2],out int age))
                {
                    problems.AppendLine($"age is not a number: \"{line}\"");
                    continue;
                }

                Console.WriteLine($"{parts[0],-12}{parts[1],-14}{age,5}");
                valid++;

            }

            Console.WriteLine(new string('-', 31));
            Console.WriteLine($"{valid} of {lines.Length} rows parsed.");

            if(problems.Length > 0)
            {
                Console.WriteLine();
                Console.WriteLine("Problems:");
                Console.Write(problems.ToString());
            }

        }
    }
}