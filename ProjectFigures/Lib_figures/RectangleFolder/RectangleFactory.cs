using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class RectangleFactory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Прямоугольник";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return new Lib_figures.Rectangle(figure_Parametrs);
        }
    }
}
