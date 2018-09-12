using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    class Program
    {
        static void Main(string[] args)
        {



            List<Shape> shapes = new List<Shape>
            {
                //new Square(5),
                new Triangle()
               // new Circle(),
                //new Rectangle(),

            };

            foreach (var shape in shapes)
            {
                shape.GetArea();
                shape.GetPerim();
            }
        }
    }

    interface IShape
    {
        double GetArea();

        int Type { get; set; }
    }

    public abstract class Shape
    {
        public abstract double GetArea();

        public double GetPerim()
        {
            return 0;
        }

        public void PrintColor(string colir)
        {
            Console.WriteLine(colir);
        }
    }

    class Square : IShape
    {
        public double Side { get; set; }

        public Square(double side)
        {
            Side = side;
        }

        public double GetArea()
        {
            return Side * Side;
        }

        public int Type { get; set; }
    }

    class Triangle : Shape
    {
        public override double GetArea()
        {
            throw new NotImplementedException();
        }
    }

    //class Circle : IShape
    //{
    //    public Circle()
    //    {

    //    }
    //}

    //class Rectangle : IShape
    //{
    //    private readonly double sideA;
    //    private readonly double sideB;

    //    public Rectangle(double sideA, double sideB)
    //    {
    //        this.sideA = sideA;
    //        this.sideB = sideB;
    //    }
    //}
}
