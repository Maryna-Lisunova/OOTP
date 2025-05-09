﻿using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Circle : Base_Figure, IResizeable
    {
        private int _radius = 0;
        public Circle(Figure_Parametrs parametrs) : base(parametrs)
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
