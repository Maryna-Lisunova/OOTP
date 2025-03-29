using System.Drawing;

namespace Lib_figures
{
    public class Rectangle : Base_Figure
    {
        // конструктор для deсериалайзера
        public Rectangle() : base()
        {
        }

        public Rectangle(Figure_Parametrs figure_Parametrs) : base(figure_Parametrs)
        {
        }

        public override string Name
        {
            get
            {
                return "Прямоугольник";
            }
        }
        public override void Draw(Graphics graphics)
        {
            base.Draw(graphics);
            graphics.DrawRectangle(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, 100, 180);
        }
    }
}
