using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class Program
    {
        static void Main(string[] args)
        {
            Shape[] myShapes =
                {new Hexagon(), new Circle(), new Hexagon("Mick"),
                    new Circle("Beth"), new Hexagon("Linda"), new ThreeDCircle() };

            foreach (var shape in myShapes)
            {
                shape.Draw();
            }

            Circle dCircle = new ThreeDCircle();
            dCircle.Draw();

            Console.ReadLine();
        }
    }
}