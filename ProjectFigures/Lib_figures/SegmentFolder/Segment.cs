using Core;
using System;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Segment : Base_Figure, IResizeable
    {
        private List<Point> points = new List<Point>();
        public Segment(Figure_Parametrs parametrs) : base(parametrs)
        {
            points.Add(new Point(parametrs.X, parametrs.Y));
        }

        // override - переопределяю, задаю новое поведеніе
        public override string Name
        {
            get
            {
                return "Отрезок";
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
        public void Resize(int x, int y)
        {
            points.Add(new Point(x, y));            
        }
    }
}
