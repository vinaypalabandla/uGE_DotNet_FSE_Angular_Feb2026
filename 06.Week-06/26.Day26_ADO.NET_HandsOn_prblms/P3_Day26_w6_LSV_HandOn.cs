using System;

namespace LSPExample
{
    // Base Class
    abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Rectangle Class
    class Rectangle : Shape
    {
        public double Length { get; set; }
        public double Width { get; set; }

        public override double CalculateArea()
        {
            return Length * Width;
        }
    }

    // Circle Class
    class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return 3.14 * Radius * Radius;
        }
    }

    class Program
    {
        static void PrintArea(Shape shape)
        {
            Console.WriteLine("Area: " + shape.CalculateArea());
        }

        static void Main(string[] args)
        {
            Shape rect = new Rectangle { Length = 10, Width = 5 };
            Shape circle = new Circle { Radius = 7 };

            PrintArea(rect);
            PrintArea(circle);

            Console.ReadLine();
        }
    }
}