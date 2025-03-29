namespace Lib_figures
{
    public class Segment_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Отрезок";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {                       
            return new Lib_figures.Segment(figure_Parametrs);
        }
    }
}
