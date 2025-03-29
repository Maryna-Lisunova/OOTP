using System.Drawing;
using Lib_figures;

namespace Lib_Broken_line
{
    public class Broken_line_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override Base_Figures Create(Figure_Parametrs figure_Parametrs)
        {
            var figure = new Lib_Broken_line.Broken_line();
            figure.figure_Parametrs.X = figure_Parametrs.X;
            figure.figure_Parametrs.Y = figure_Parametrs.Y;
            figure.figure_Parametrs.MyPen = figure_Parametrs.MyPen;
            return figure;
        }
    }

    public class Broken_line : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override void Draw(Graphics graphics, Figure_Parametrs figure_Parametrs)
        {
            base.Draw(graphics, figure_Parametrs);

            Point[] points = new Point[]
            {
                new Point(figure_Parametrs.X, figure_Parametrs.Y),
                new Point(figure_Parametrs.X + 100, figure_Parametrs.Y + 50),
                new Point(figure_Parametrs.X + 200, figure_Parametrs.Y + 20),
                new Point(figure_Parametrs.X + 300, figure_Parametrs.Y + 100),
                new Point(figure_Parametrs.X + 400, figure_Parametrs.Y + 30)
            };

            graphics.DrawLines(figure_Parametrs.MyPen, points);
        }
    }
}
