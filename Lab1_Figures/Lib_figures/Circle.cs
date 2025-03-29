using System.Drawing;

namespace Lib_figures
{
    public class Circle : Base_Figure
    {
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
            graphics.DrawEllipse(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, 100, 100);
        }
    }
}
