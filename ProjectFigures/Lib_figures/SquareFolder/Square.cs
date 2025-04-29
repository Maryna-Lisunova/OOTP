using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Square : Base_Figure
    {
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }

        public Square(Figure_Parametrs parametrs) : base(parametrs)
        {
        }

        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            if (_myPen == null)
            {
                return;
            }
            else
            {
                graphics.DrawRectangle(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, 100, 100);
            }                
        }
    }
}
