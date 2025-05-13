using Core;
using System.Drawing;

namespace Lib_figures
{
    [Figure]
    public class Rectangle : Base_Figure, IResizeable
    {
        [Newtonsoft.Json.JsonProperty]
        private int end_x = 0;
        [Newtonsoft.Json.JsonProperty]
        private int end_y = 0;

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
            using (SolidBrush fillBrush = new SolidBrush(Figure_Parametrs.BackColor))
            {
                graphics.FillRectangle(fillBrush, Figure_Parametrs.X, Figure_Parametrs.Y, end_x, end_y);
            }
            graphics.DrawRectangle(_myPen, Figure_Parametrs.X, Figure_Parametrs.Y, end_x, end_y);
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
