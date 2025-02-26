using System.Drawing;

namespace Lib_figures
{
    public class Base_Figure_Factory
    {
        public virtual string Name { get; }        
        public virtual Base_Figures Create(int x, int y)
        {
            return null;
        }
    }

    public class Segment_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Отрезок";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Segment();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Square_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Square();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Rectangle_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Прямоугольник";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Rectangle();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Circle_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Круг";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Circle();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Ellipse_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Эллипс";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Ellipse();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Polygon_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Polygon();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }

    public class Broken_line_Factory : Base_Figure_Factory
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override Base_Figures Create(int x, int y)
        {
            var figure = new Lib_figures.Broken_line();
            figure.X = x;
            figure.Y = y;
            return figure;
        }
    }
   
    ///////////////////////////////////////////////////////////////////////
    
    public class Base_Figures
    {
        // virtual - поведеніе можно переопределіть
        public virtual string Name { get; }
        public int X { get; set; } 
        public int Y { get; set; } 
        public virtual void Draw(Graphics graphics, int x, int y)
        {

        }
    }

    public class Segment : Base_Figures
    {
        // override - переопределяю, задаю новое поведеніе
        public override string Name
        {
            get
            {
                return "Отрезок";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);
            graphics.DrawLine(Pens.Black, x, y, x + 100, y + 100);
        }
    }

    public class Square : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Квадрат";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);
            graphics.DrawRectangle(Pens.Black, x, y, 100, 100);
        }
    }

    public class Rectangle : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Прямоугольник";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);
            graphics.DrawRectangle(Pens.Black, x, y, 100, 180);
        }
    }

    public class Circle : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Круг";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);
            graphics.DrawEllipse(Pens.Black, x, y, 100, 100);
        }
    }

    public class Ellipse : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Эллипс";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);
            graphics.DrawEllipse(Pens.Black, x, y, 150, 100);
        }
    }

    public class Polygon : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Многоугольник";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);

            Point[] points = new Point[]
            {
                new Point(x + 50, y + 50),
                new Point(x + 150, y + 50),
                new Point(x + 200, y + 100),
                new Point(x + 150, y + 150),
                new Point(x + 50, y + 150),
                new Point(x + 0, y + 100)
            };

            graphics.DrawPolygon(Pens.Black, points);
        }
    }

    public class Broken_line : Base_Figures
    {
        public override string Name
        {
            get
            {
                return "Ломаная линия";
            }
        }
        public override void Draw(Graphics graphics, int x, int y)
        {
            base.Draw(graphics, x, y);

            Point[] points = new Point[]
            {
                new Point(x, y),
                new Point(x + 100, y + 50),
                new Point(x + 200, y + 20),
                new Point(x + 300, y + 100),
                new Point(x + 400, y + 30)
            };

            graphics.DrawLines(Pens.Black, points);
        }
    }
}
