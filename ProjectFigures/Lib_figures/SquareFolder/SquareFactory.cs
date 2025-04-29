using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class SquareFactory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return new Lib_figures.Square(figure_Parametrs);
        }
    }
}
