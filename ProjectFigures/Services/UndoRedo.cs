using Core;

namespace Services
{
    public class UndoRedo
    {
        public void Undo(ref List<Base_Figure> my_figures, ref List<Base_Figure> my_figures_redo)
        {
            Base_Figure figure = my_figures.Last();
            my_figures.Remove(figure);
            my_figures_redo.Add(figure);
        }

        public void Redo(ref List<Base_Figure> my_figures, ref List<Base_Figure> my_figures_redo)
        {
            Base_Figure figure = my_figures_redo.Last();
            my_figures_redo.Remove(figure);
            my_figures.Add(figure);
        }
    }
}
