using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class Ellipse_Factory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Эллипс";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.Ellipse(figure_Parametrs);
        }
    }
}
