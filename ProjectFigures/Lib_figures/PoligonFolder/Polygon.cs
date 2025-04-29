using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Polygon : Base_Figure
    {
        public Polygon(Figure_Parametrs parametrs) : base(parametrs)
        {
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

            Point[] points = new Point[]
            {
                new Point(Figure_Parametrs.X + 50, Figure_Parametrs.Y + 50),
                new Point(Figure_Parametrs.X + 150, Figure_Parametrs.Y + 50),
                new Point(Figure_Parametrs.X + 200, Figure_Parametrs.Y + 100),
                new Point(Figure_Parametrs.X + 150, Figure_Parametrs.Y + 150),
                new Point(Figure_Parametrs.X + 50, Figure_Parametrs.Y + 150),
                new Point(Figure_Parametrs.X + 0, Figure_Parametrs.Y + 100)
            };

            graphics.DrawPolygon(_myPen, points);
        }
    }
}
