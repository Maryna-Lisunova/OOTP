using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class Ellipse_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Эллипс";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return new Lib_figures.Ellipse(figure_Parametrs);
        }
    }
}
