using System;
using System.Drawing;
using System.Text.Json.Serialization;
using Core;
using Newtonsoft.Json;

namespace Lib_figures
{
    [Figure]
    public class BrokenLine : BaseFigure, IArbitrary
    {
        [Newtonsoft.Json.JsonProperty]
        private List<Point> points = new List<Point>();

        [Newtonsoft.Json.JsonConstructor]
        public BrokenLine([Newtonsoft.Json.JsonProperty("Figure_Parametrs")] FigureParametrs parametrs) : base(parametrs)
        {
            points = new List<Point>();
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
