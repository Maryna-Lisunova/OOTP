namespace Core
{
    public abstract class BaseFigureFactory
    {
        public abstract string Name { get; }
        public abstract BaseFigure Create(FigureParametrs figure_Parametrs);        
    }
}
