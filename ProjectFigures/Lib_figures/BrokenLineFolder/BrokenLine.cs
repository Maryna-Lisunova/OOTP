using System;
using System.Drawing;
using Core;

namespace Lib_figures
{
    [Figure]
    public class BrokenLine : Base_Figure, IArbitrary
    {
        private List<Point> points = new List<Point>();
        public BrokenLine(Figure_Parametrs parametrs) : base(parametrs)
        {
            points.Add(new Point(parametrs.X, parametrs.Y));
        }

        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);            

            if (points.Count >= 2)
            {
                graphics.DrawLines(_myPen, points.ToArray());
            }
        }

        public void Continue(int x, int y)
        {
            points.Add(new Point(x, y));
        }

        public void Stop(int x, int y)
        {

        }
    }
}
