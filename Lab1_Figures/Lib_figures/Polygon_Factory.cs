namespace Lib_figures
{
    public class Polygon_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {  
            return new Lib_figures.Polygon(figure_Parametrs);
        }
    }
}
