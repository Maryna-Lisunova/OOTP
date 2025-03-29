namespace Lib_figures
{
    public class Broken_line_Factory : Base_Figure_Factory
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
            return new Lib_figures.Broken_line(figure_Parametrs);
        }
    }
}
