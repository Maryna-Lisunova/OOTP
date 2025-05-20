using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class SquareFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.Square(figure_Parametrs);
        }
    }
}
