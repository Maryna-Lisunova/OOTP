using System.Drawing;
using Lib_figures;

namespace Lab1_Figures
{
    public partial class Main_Form : Form
    {
        private List<Base_Figures> my_figures;
        private List<Base_Figure_Factory> my_figures_factory;
        public Main_Form()
        {
            InitializeComponent();
            ispencolor = true;

            my_figures = new List<Base_Figures>();

            my_figures_factory = new List<Base_Figure_Factory>();
            my_figures_factory.Add(new Lib_figures.Segment_Factory());
            my_figures_factory.Add(new Lib_figures.Square_Factory());
            my_figures_factory.Add(new Lib_figures.Rectangle_Factory());
            my_figures_factory.Add(new Lib_figures.Circle_Factory());
            my_figures_factory.Add(new Lib_figures.Ellipse_Factory());
            my_figures_factory.Add(new Lib_figures.Polygon_Factory());
            my_figures_factory.Add(new Lib_figures.Broken_line_Factory());
        }

        Point click_position;
        Graphics graphics;
        Color pencolor;
        Color backcolor;
        bool ispencolor;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            foreach (var figure in my_figures_factory)
            {
                cb_figyres.Items.Add(figure.Name);
            }
        }
        private void Main_Form_Paint(object sender, PaintEventArgs e)
        {
            foreach (var figure in my_figures)
            {
                figure.Draw(e.Graphics, figure.X, figure.Y);
            }
        }

        private void Main_Form_MouseClick(object sender, MouseEventArgs e)
        {
            click_position = e.Location;
            graphics = CreateGraphics();
            // backcolor
            int pen_height = trackBar_pen.Value;
            string choosen_figyre = cb_figyres.SelectedItem as string;
            int corners = trackBar_corners.Value;

            foreach (var figure_factory in my_figures_factory)
            {
                if (choosen_figyre == figure_factory.Name)
                {
                    var figure = figure_factory.Create(e.X, e.Y);
                    my_figures.Add(figure);
                    figure.Draw(graphics, figure.X, figure.Y);
                    return;
                }
            }

            this.Invalidate();
        }

        private void button_backcolor_Click(object sender, EventArgs e)
        {
            if (ispencolor)
            {
                pencolor = ((Button)sender).BackColor;
                btn_pencolor.BackColor = pencolor;
                ispencolor = false;
            }
            else
            {
                backcolor = ((Button)sender).BackColor;
                btn_backcolor.BackColor = backcolor;
                ispencolor = true;
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            my_figures.Clear();
        }

        private void trackBar_pen_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
