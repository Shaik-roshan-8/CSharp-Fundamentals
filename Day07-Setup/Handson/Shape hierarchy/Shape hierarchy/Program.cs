using System;
using System.Security.Cryptography.X509Certificates;
namespace Day07
{
    class Program
    {
        public static void Main()
        {
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4, 6);
            Shape square = new Square(4, 4);
            Shape triangle = new Triangle(3, 4, 5);
            Shape hexagon = new Hexagon(6);

            Shape[] shapes = new Shape[]
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Square(4, 4),
                new Triangle(3, 4, 5),
                new Hexagon(6)
            };
            shapes.Sort((s1, s2) => s1.Area().CompareTo(s2.Area()));
            Report(shapes);



        }
        public static void Report (Shape[] shapes)
        {
            Console.WriteLine(new string('-', 45));
            Console.WriteLine("{0,-10} {1,-10} {2,10} {3,10}", "Shape", "Dimensions", "Area", "Perimeter");
            Console.WriteLine(new string('-', 45));

            double totalarea = 0; // we have to declare a variable and initialize  first before incrementing the value +=
            foreach (var shape in shapes)
            {
                double area = shape.Area();
                double perimeter = shape.Perimeter();
                totalarea += area;
                Console.WriteLine("{0,-10} {1,-10} {2,10:F2} {3,10:F2}",
                    shape.Name, shape.Dimensions, area, perimeter);
            }

            Console.WriteLine(new string('-', 45));
            Console.WriteLine("{0,-10} {1,-10} {2,10:F2}", "TOTAL", "", totalarea);

        }

    }
    abstract class Shape
    {
        public abstract double Area();
        public abstract double Perimeter();

        public string describe()
        {
            return $"Area: {Area()}, Perimeter: {Perimeter()}";
        }
        public abstract string Name { get; }
        public abstract string Dimensions { get; }
    }
    class Circle : Shape , IResizable
    {
        private double radius;
        public override string Name => "Circle";
        public override string Dimensions => $"r={radius}";
        public Circle(double radius)
        {
            this.radius = radius;
        }
        public override double Area()
        {
            return Math.PI * radius * radius;
        }
        public override double Perimeter()
        {
            return 2 * Math.PI * radius;
        }
        public void Scale (double Factor)
        {
            radius *= Factor;
        }
    }
    class Rectangle : Shape, IResizable
    {
        private double width;
        private double height;
        public override string Name => "Rectangle";
        public override string Dimensions => $"{height}x{width}";
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public override double Area()
        {
            return width * height;
        }
        public override double Perimeter()
        {
            return 2 * (width + height);
        }
        public void Scale(double Factor)
        {
            width *= Factor;
            height *= Factor;
        }
    }
    class Square : Rectangle, IResizable
    {
        public override string Name => "Square";
        public override string Dimensions => $"{base.Dimensions}";

        public Square(double side1, double side2) : base(side1, side2)
        {
            if (side1 != side2)
            {
                throw new ArgumentException("For a square, both sides must be equal.");
            }
        }
        public override double Area()
        {
            return base.Area();
        }
        public override double Perimeter()
        {
            return base.Perimeter();
        }

        public new void Scale(double Factor)
        {
            base.Scale(Factor);
        }

    }
    class Triangle : Shape, IResizable
    {
        private double side1;
        private double side2;
        private double side3;
        public override string Name => "Triangle";
        public override string Dimensions => $"{side1}x{side2}x{side3}";
        public Triangle(double side1, double side2, double side3)
        {
            if(side1 + side2 <= side3 || side1 + side3 <= side2 || side2 + side3 <= side1)
            {
                throw new ArgumentException("The sum of any two sides must be greater than the third side.");
            }
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        public override double Area()
        {
            double s = (side1 + side2 + side3) / 2;
            return Math.Sqrt(s * (s - side1) * (s - side2) * (s - side3));
        }
        public override double Perimeter()
        {
            return side1 + side2 + side3;
        }
        public void Scale(double Factor)
        {
            side1 *= Factor;
            side2 *= Factor;
            side3 *= Factor;
        }
    }

    // creating class hexagon
    class Hexagon : Shape, IResizable
    {
        private double side;
        public override string Name => "Hexagon";
        public override string Dimensions => $"s={side}";
        public Hexagon(double side)
        {
            this.side = side;
        }
        public override double Area()
        {
            return (3 * Math.Sqrt(3) / 2) * side * side;
        }
        public override double Perimeter()
        {
            return 6 * side;
        }
        public void Scale(double Factor)
        {
            side *= Factor;
        }
    }

    // adding interface 
    interface IResizable
    {
        public void Scale(double Factor);
    }
        

}