using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ObjectInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("*****  Fun  with  Object  Init  Syntax  *****\n");

            //  Создать  объект  Point  с  установкой  каждого  свойства  вручную.

            Point firstPoint = new Point();

            firstPoint.X = 10;

            firstPoint.Y = 10;

            firstPoint.DisplayStats();

            //  Создать  объект  Point  с  использованием  специального  конструктора.

            Point anotherPoint = new Point(20, 20);

            anotherPoint.DisplayStats();

            //  Создать  объект-Point  с  использованием  синтаксиса  инициализатора  объекта.

            Point finalPoint = new Point
            {
                X = 30,
                Y = 30
            };

            finalPoint.DisplayStats();

            Point goldPoint = new Point(PointColor.LightBlue) { X = 90, Y = 20 };
            goldPoint.DisplayStats();

            Rectangle myRectangle = new Rectangle
            {
                TopLeft = new Point {X = 10, Y = 10},
                BottomRight = new Point {X = 200, Y = 200}
            };

            myRectangle.DisplayStats();

            Console.ReadLine();
        }

       


        class Point
        {
          
            public int X { get; set; }
            public int Y { get; set; }
            public PointColor Color { get; set; }

            public Point(int x, int y)
            {
                X = x;
                Y = y;
                Color = PointColor.Gold;
            }

            public Point(PointColor ptColor)
            {
                Color = ptColor;
                // Color = PointColor.LightBlue;
            }

            public Point() : this(PointColor.BloodRed) { }

            public void DisplayStats()
            {
                Console.WriteLine($"[{X}, {Y}]");
                Console.WriteLine($"Point is {Color}");
            }
        }

        public enum PointColor
        {
            LightBlue,
            BloodRed,
            Gold
        }

        class Rectangle
        {
            private Point topLeft = new Point();
            private Point bottomRight = new Point();

            public Point TopLeft
            {
                get { return topLeft; }
                set { topLeft = value; }
            }

            public Point BottomRight
            {
                get { return bottomRight; }
                set { bottomRight = value; }
            }

            public void DisplayStats()

            {

                Console.WriteLine("[TopLeft:  {0},  {1},  {2}  BottomRight:  {3},  {4},  {5}]",

                    topLeft.X, topLeft.Y, topLeft.Color,

                    bottomRight.X, bottomRight.Y, bottomRight.Color);

            }

        }
    }
}