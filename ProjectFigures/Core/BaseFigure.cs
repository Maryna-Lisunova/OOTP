using System.Drawing;
using System.Windows;

namespace Core
{
    public abstract class BaseFigure
    {
        // virtual - поведеніе можно переопределіть
        // contructor
        public BaseFigure(FigureParametrs parametrs)
        {
            Figure_Parametrs = parametrs;
        }

        public BaseFigure()
        {

        }

        public string TypeName
        {
            get
            {
                var type = GetType();
                return type.Name;
            }
        }
        public virtual string Name { get; }
        // pole, в пределах наследников
        protected Pen _myPen;
        private FigureParametrs figure_Parametrs;

        public FigureParametrs Figure_Parametrs
        {
            get => figure_Parametrs;
            set
            {
                figure_Parametrs = value;
                if (value != null)
                {
                    _myPen = new Pen(value.Pen_Color, value.Pen_Height);
                }
            }
        }
        public virtual void Draw(Graphics graphics)
        {

        }
    }
}
