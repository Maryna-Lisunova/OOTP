using Core;
using System.Drawing;
using System.Reflection.Metadata;

namespace PlugginTrapezoid
{
    [Figure]
    public class Trapezoid : BaseFigure, IResizeable
    {
        [Newtonsoft.Json.JsonProperty]
        private int end_x = 0;
        [Newtonsoft.Json.JsonProperty]
        private int end_y = 0;
        [Newtonsoft.Json.JsonProperty]
        private List<Point> points = new List<Point>();
        public Trapezoid(FigureParametrs figure_Parametrs) : base(figure_Parametrs)
        {
        }

        public override string Name
        {
            get
            {
                return "Трапеция";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            points.Clear();
            // отступ
            int indent = Math.Abs(end_x - Figure_Parametrs.X) / 4;

            points.Add(new Point(Figure_Parametrs.X, end_y));
            points.Add(new Point(Figure_Parametrs.X + indent, Figure_Parametrs.Y));
            points.Add(new Point(end_x - indent, Figure_Parametrs.Y));
            points.Add(new Point(end_x, end_y));
            points.Add(new Point(Figure_Parametrs.X, end_y));

            using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
            {
                graphics.FillPolygon(fillBrush, points.ToArray());
            }
            graphics.DrawLines(_myPen, points.ToArray());
        }

        public void Resize(int x, int y)
        {
            end_x = x;
            end_y = y;
        }
    }
}
