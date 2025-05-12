using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class FreeLineFactory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Произвольная линия";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {                       
            return new Lib_figures.FreeLine(figure_Parametrs);
        }
    }
}
