using System.Drawing;

namespace Lib_figures
{
    public class Segment : Base_Figure
    {
        public Segment(Figure_Parametrs parametrs) : base(parametrs)
        {
        }

        // override - переопределяю, задаю новое поведеніе
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
            graphics.DrawLine(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, Figure_Parametrs.X + 100, Figure_Parametrs.Y + 100);
        }
    }
}
