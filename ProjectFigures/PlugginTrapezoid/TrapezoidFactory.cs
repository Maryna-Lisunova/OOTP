using Core;

namespace PlugginTrapezoid
{
    [FigureFactory]
    public class TrapezoidFactory : BaseFigureFactory
    {
        public override string Name
        {
            get
            {
                return "Трапеция";
            }
        }
        public override BaseFigure Create(FigureParametrs figure_Parametrs)
        {
            return new PlugginTrapezoid.Trapezoid(figure_Parametrs);
        }
    }
}
