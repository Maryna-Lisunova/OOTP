using Core;
using System;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Square : BaseFigure, IResizeable
    {
        [Newtonsoft.Json.JsonProperty]
        private int _side = 0;
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }

        public Square(FigureParametrs parametrs) : base(parametrs)
        {
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
            {
                graphics.FillRectangle(fillBrush, Figure_Parametrs.X, Figure_Parametrs.Y, _side, _side);
            }
            graphics.DrawRectangle(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, _side, _side);
            
        }

        public void Resize(int x, int y)
        {
            int side = 0;
            int weight = x - Figure_Parametrs.X;
            int height = y - Figure_Parametrs.Y;
            if (Math.Abs(weight) < Math.Abs(height))
            {
                side = weight;
            }
            else
            {
                side = height;
            }
            _side = side;
        }
    }
}
