using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using Core;

namespace Lib_figures
{
    [Figure]
    public class Segment : Base_Figure, IResizeable
    {
        private int end_x = 0;
        private int end_y = 0;
        public Segment(Figure_Parametrs parametrs) : base(parametrs)
        {
        }

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
            graphics.DrawLine(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, end_x, end_y);
        }

        public void Resize(int x, int y)
        {
            end_x = x;
            end_y = y;
        }
    }
}
