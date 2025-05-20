using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Circle : BaseFigure, IResizeable
    {
        [Newtonsoft.Json.JsonProperty]
        private int _radius = 0;
        public Circle(FigureParametrs parametrs) : base(parametrs)
        {
        }

        public override string Name
        {
            get
            {
                return "Круг";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);

            using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
            {
                graphics.FillEllipse(fillBrush, Figure_Parametrs.X, Figure_Parametrs.Y, _radius, _radius);
            }

            graphics.DrawEllipse(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, _radius, _radius);
        }

        public void Resize(int x, int y)
        {
            int radius = 0;
            int weight = x - Figure_Parametrs.X;
            int height = y - Figure_Parametrs.Y;
            if (Math.Abs(weight) < Math.Abs(height))
            {
                radius = weight;
            }
            else
            {
                radius = height;
            }
            _radius = radius;            
        }
    }
}
