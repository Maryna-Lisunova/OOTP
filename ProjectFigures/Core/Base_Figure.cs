using System.Drawing;
using System.Windows;

namespace Core
{
    public abstract class Base_Figure
    {
        // virtual - поведеніе можно переопределіть
        // contructor
        public Base_Figure(Figure_Parametrs parametrs)
        {
            Figure_Parametrs = parametrs;
        }

        public Base_Figure()
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
        private Figure_Parametrs figure_Parametrs;

        public Figure_Parametrs Figure_Parametrs
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
