using Core;

namespace Lib_figures
{
    [FigureFactory]

    public class CircleFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Круг";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.Circle(figure_Parametrs);
        }
    }
}
