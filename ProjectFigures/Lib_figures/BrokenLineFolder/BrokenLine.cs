﻿using System.Drawing;
using Core;

namespace Lib_figures
{
    [Figure]
    public class BrokenLine : Base_Figure
    {
        public BrokenLine(Figure_Parametrs parametrs) : base(parametrs)
        {
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

            Point[] points = new Point[]
            {
                new Point(Figure_Parametrs.X, Figure_Parametrs.Y),
                new Point(Figure_Parametrs.X + 100, Figure_Parametrs.Y + 50),
                new Point(Figure_Parametrs.X + 200, Figure_Parametrs.Y + 20),
                new Point(Figure_Parametrs.X + 300, Figure_Parametrs.Y + 100),
                new Point(Figure_Parametrs.X + 400, Figure_Parametrs.Y + 30)
            };

            graphics.DrawLines(_myPen, points);
        }
    }
}
