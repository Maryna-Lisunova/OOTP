using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class PolygonFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {  
            return new Lib_figures.Polygon(figure_Parametrs);
        }
    }
}
