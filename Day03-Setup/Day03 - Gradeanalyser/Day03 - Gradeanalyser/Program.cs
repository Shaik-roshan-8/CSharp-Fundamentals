using System;
namespace Day03
{
    class Gradeanalyser
    {
        static void Main(string[] args)
        {
            int students = 0;
            Console.WriteLine("Enter the number of students");
            string? s = Console.ReadLine();
            int.TryParse(s, out students );

            //tracking variables learned with AI
            int highest = int.MinValue; 
            int lowest = int.MaxValue;
            int sum = 0;
            int countA = 0 , countB = 0 , countC = 0 , countD = 0 , countE = 0 ,countF = 0 ;

            for ( int i = 1; i <= students; i++ )
            {
                int marks = 0;

                while (true)
                {
                    Console.WriteLine("Enter the marks of the student");
                     string? m = Console.ReadLine();
                    int.TryParse(m, out marks);
                    if (marks >= 0 && marks <= 100)
                        break;
                    Console.WriteLine("Enter valid marks 0 to 100");

                }
                if(marks>highest)
                {
                    highest = marks;
                }
                if (marks < lowest)
                {
                    lowest = marks;
                }

                sum += marks;

                if (marks >= 90) countA++;
                else if (marks >=80) countB++;
                else if(marks >=70) countC++;
                else if(marks>=60) countD++;
                else countF++;


            }
            double Average = (double)sum / students;

            //printing 
            Console.WriteLine($"Highest : {highest}");
            Console.WriteLine($"Lowest : {lowest}");
            Console.WriteLine($"Average : {Average:F2}");

            Console.WriteLine($"Grade A : {countA}");
            Console.WriteLine($"Grade B : {countB}");
            Console.WriteLine($"Grade c : {countC}");
            Console.WriteLine($"Grade D : {countD}");
            Console.WriteLine($"Grade E : {countE}");
            Console.WriteLine($"Grade F : {countF}");

            //histogram 

            Console.WriteLine("===============Histogram===============");
            Console.Write("A"); for (int i = 0; i < countA; i++) { Console.Write("#"); }
                Console.WriteLine();
                Console.Write("B"); for (int i = 0; i < countB; i++) { Console.Write("#"); }
                    Console.WriteLine();
                    Console.Write("C");for (int i = 0; i < countC; i++) { Console.Write("#"); }
                        Console.WriteLine();
                        Console.Write("D");for (int i = 0; i < countD; i++) { Console.Write("#"); }
                            Console.WriteLine();
                            Console.Write("E");for (int i = 0; i < countE; i++) { Console.Write("#"); }
                                Console.WriteLine();
                                Console.Write("F");for (int i = 0; i < countF; i++) { Console.Write("#"); }
                                    Console.WriteLine();

            }

        }
    }

