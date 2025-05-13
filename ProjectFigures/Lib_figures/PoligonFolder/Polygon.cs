using Core;
using System;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Polygon : Base_Figure, IArbitrary
    {
        [Newtonsoft.Json.JsonProperty]
        bool finish = false;
        [Newtonsoft.Json.JsonProperty]
        private List<Point> points = new List<Point>();
        public Polygon([Newtonsoft.Json.JsonProperty("Figure_Parametrs")] Figure_Parametrs parametrs) : base(parametrs)
        {
            points.Add(new Point(parametrs.X, parametrs.Y));
        }

        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            if (points.Count >= 2)
            {
                if (finish)
                {
                    using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
                    {
                        graphics.FillPolygon(fillBrush, points.ToArray());
                    }
                    graphics.DrawPolygon(_myPen, points.ToArray());
                }
                else
                {
                    graphics.DrawLines(_myPen, points.ToArray());
                }
            }
        }

        public void Continue(int x, int y)
        {
            points.Add(new Point(x, y));
        }

        public void Stop(int x, int y)
        {
            points.Add(new Point(x, y));
            finish = true;
        }
    }
}
