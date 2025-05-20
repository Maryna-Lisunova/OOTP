using Core;

namespace Services
{
    public class UndoRedo
    {
        public void Undo(ref List<BaseFigure> my_figures, ref List<BaseFigure> my_figures_redo)
        {
            BaseFigure figure = my_figures.Last();
            my_figures.Remove(figure);
            my_figures_redo.Add(figure);
        }

        public void Redo(ref List<BaseFigure> my_figures, ref List<BaseFigure> my_figures_redo)
        {
            BaseFigure figure = my_figures_redo.Last();
            my_figures_redo.Remove(figure);
            my_figures.Add(figure);
        }
    }
}
