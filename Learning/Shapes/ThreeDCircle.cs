using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shapes
{
    class ThreeDCircle : Circle
    {
        protected new string ShapeName;

        public new void Draw()
        {
            Console.WriteLine("Drawing a 3D Circlle");
        }
    }
}
