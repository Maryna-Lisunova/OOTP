using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class RectangleFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Прямоугольник";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.Rectangle(figure_Parametrs);
        }
    }
}
