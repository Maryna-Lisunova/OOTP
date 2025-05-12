using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Ellipse : Base_Figure
    {
        public Ellipse(Figure_Parametrs parametrs) : base(parametrs)
        {
        }

        public override string Name
        {
            get
            {
                return "Эллипс";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.DrawEllipse(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, 150, 200);
                        
            //Brush brush = new SolidBrush(Color.LightGreen);
            //Rectangle circleBounds = new Rectangle(Figure_Parametrs.X, Figure_Parametrs.Y, 150, 200);
            //graphics.FillEllipse(brush, circleBounds);
            //graphics.DrawEllipse(_myPen, circleBounds);
        }
    }
}
