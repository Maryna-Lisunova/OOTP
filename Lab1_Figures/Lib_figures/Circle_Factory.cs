namespace Lib_figures
{
    public class Circle_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Круг";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return new Lib_figures.Circle(figure_Parametrs);
        }
    }
}
