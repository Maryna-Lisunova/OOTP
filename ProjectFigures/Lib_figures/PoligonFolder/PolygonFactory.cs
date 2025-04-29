using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class PolygonFactory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {  
            return new Lib_figures.Polygon(figure_Parametrs);
        }
    }
}
