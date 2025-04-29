using Core;

namespace Lib_figures
{
    [FigureFactory]
    public class BrokenLineFactory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return new Lib_figures.BrokenLine(figure_Parametrs);
        }
    }
}
