using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class BrokenLineFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.BrokenLine(figure_Parametrs);
        }
    }
}
