namespace Core
{
    public abstract class Base_Figure_Factory
    {
        public abstract string Name { get; }
        public abstract Base_Figure Create(Figure_Parametrs figure_Parametrs);        
    }
}
