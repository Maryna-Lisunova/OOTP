namespace Lib_figures
{
    public class Base_Figure_Factory
    {
        public virtual string Name { get; }        
        public virtual Base_Figure Create(Figure_Parametrs figure_Parametrs)
        {
            return null;
        }
    }
}
