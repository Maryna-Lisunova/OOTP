using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class SegmentFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Отрезок";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new Lib_figures.Segment(figure_Parametrs);
        }
    }
}
