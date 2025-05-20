using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class FreeLineFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Произвольная линия";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {                       
            return new Lib_figures.FreeLine(figure_Parametrs);
        }
    }
}
