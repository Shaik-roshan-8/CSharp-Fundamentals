using System;
using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
namespace Day06
{
    class Student
    {
        public int RollNumber;
        public string Name;

        private int[] _marks = new int[5];

        public int Total
        {
            get
            {
                int sum = 0;
                for (int i = 1; i < _marks.Length; i++)
                {
                    sum += _marks[i];
                }
                return sum;
            }
        }
        public double Percentage
        {
            get
            {
                return (Total / 500.0) * 100;
            }
        }
        public string Grade
        {
            get
            {
                double p = Percentage;
                if (p >= 90.0) return "A";
                else if (p >= 75.0) return "B";
                else if (p >= 60.0) return "C";
                else if (p >= 40.0) return "D";
                else return "F";

            }
        }
        public Student(int  rollNumber, string name)
        {
            this.RollNumber = rollNumber;
            this.Name= name;
        }
        public bool SetMark (int subjectIndex , int marks)
        {
            if( marks<0 || marks >100)
            {
                Console.WriteLine($"Invalid mark: {marks}");
                return false;
            }
            if (subjectIndex < 0 || subjectIndex > _marks.Length)
            {
                Console.WriteLine($"Invalid subject index: {subjectIndex}");
                return false;
            }
            _marks[subjectIndex] = marks;
            return true;
            
        }
        public static Student Topper(Student[] students)
        {
            if (students == null|| students.Length == 0)
            {
                return null;
            }
            Student Top = students[0];
            for(int i = 1; i < students.Length; i++)
            {
                if(students[i].Percentage >  Top.Percentage)
                    Top = students[i];

            }
            return Top;
        }
    }
    class Program
    {
        public static void Main()
        {
            Student[] students = new Student[3];

            students[0] = new Student(1, "Asha");
            students[0].SetMark(0, 85);
            students[0].SetMark(1, 78);
            students[0].SetMark(2, 92);
            students[0].SetMark(3, 88);
            students[0].SetMark(4, 77);

            students[1] = new Student(2, "Ravi");
            students[1].SetMark(0, 95);
            students[1].SetMark(1, 91);
            students[1].SetMark(2, 89);
            students[1].SetMark(3, 93);
            students[1].SetMark(4, 96);

            students[2] = new Student(3, "Meera");
            students[2].SetMark(0, 60);
            students[2].SetMark(1, 55);
            students[2].SetMark(2, 70);
            students[2].SetMark(3, 65);
            students[2].SetMark(4, 50);

            PrintReport(students);
            Student topper = Student.Topper(students);
            Console.WriteLine($"\nTopper: {topper.Name} with {topper.Percentage:F2}%");

        }
        static void PrintReport(Student[] students)
        {
            Console.WriteLine($"{"Roll",-6}{"Name",-10}{"Total",-8}{"Percentage",-13}{"Grade",-6}");
            foreach ( var s in students)
            {
                Console.WriteLine($"{s.RollNumber,-6}{s.Name,-10}{s.Total,-8}{s.Percentage,-13:F2}{s.Grade,-6}");
            }
        }
    }
}