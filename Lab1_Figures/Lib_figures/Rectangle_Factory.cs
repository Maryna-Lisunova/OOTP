namespace Lib_figures
{
    public class Rectangle_Factory : Base_Figure_Factory
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
