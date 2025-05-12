using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Ellipse : Base_Figure, IResizeable
    {
        private int end_x = 0;
        private int end_y = 0;
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

            using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
            {
                graphics.FillEllipse(fillBrush, Figure_Parametrs.X, Figure_Parametrs.Y, end_x, end_y);
            }
            graphics.DrawEllipse(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, end_x, end_y);                        
        }

        public void Resize(int x, int y)
        {
            int weight;
            int height;

            weight = Math.Abs(x - Figure_Parametrs.X);
            height = Math.Abs(y - Figure_Parametrs.Y);

            end_x = weight;
            end_y = height;
        }
    }
}
