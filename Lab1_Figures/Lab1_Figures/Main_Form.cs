using System.Drawing;
using Lib_figures;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Newtonsoft.Json;

namespace Lab1_Figures
{
    public partial class Main_Form : Form
    {
        private List<Base_Figure> my_figures;
        private List<Base_Figure_Factory> my_figures_factory;
        private List<Base_Figure> my_figures_redo;
        public Main_Form()
        {
            InitializeComponent();
            ispencolor = true;
            myPen = new Pen(Color.Black, 1);

            my_figures = new List<Base_Figure>();
            my_figures_redo = new List<Base_Figure>();

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
        Color pencolor = Color.Black;
        Color backcolor;
        bool ispencolor;
        Pen myPen;

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
                figure.Draw(e.Graphics);
            }
        }

        private void Main_Form_MouseClick(object sender, MouseEventArgs e)
        {
            graphics = CreateGraphics();
            click_position = e.Location;
            string choosen_figyre = cb_figyres.SelectedItem as string;
            int corners = trackBar_corners.Value;

            Figure_Parametrs figure_parametrs = new Figure_Parametrs
            {
                X = e.X,
                Y = e.Y,
                Pen_Height = trackBar_pen.Value,
                Pen_Color = pencolor,
                BackColor = backcolor
            };

            foreach (var figure_factory in my_figures_factory)
            {
                if (choosen_figyre == figure_factory.Name)
                {
                    var figure = figure_factory.Create(figure_parametrs);
                    my_figures.Add(figure);
                    my_figures_redo.Clear();
                    figure.Draw(graphics);
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

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            if (my_figures.Any())
            {
                Base_Figure figure = my_figures.Last();
                my_figures.Remove(figure);
                my_figures_redo.Add(figure);
                Invalidate();
            }
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            if (my_figures_redo.Any())
            {
                Base_Figure figure = my_figures_redo.Last();
                my_figures_redo.Remove(figure);
                my_figures.Add(figure);
                Invalidate();
            }
        }

        private void Save()
        {
            var fileDialog = new SaveFileDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                StreamWriter Writer = new StreamWriter(fileDialog.FileName);
                foreach (var figure in my_figures)
                {
                    string json = JsonConvert.SerializeObject(figure);               
                    Writer.WriteLine(json);
                }
                Writer.Close();
            }

        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void btn_desirialize_Click(object sender, EventArgs e)
        {
            var fileDialog = new OpenFileDialog();
            var result = fileDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                my_figures.Clear();

                StreamReader Reader = new StreamReader(fileDialog.FileName);
                string mystring;
                do
                {
                    mystring = Reader.ReadLine();
                    if (mystring != null)
                    {
                        var identifier = JsonConvert.DeserializeObject<Figure_Type_Identifier>(mystring);
                        if (identifier.TypeName == nameof(Circle))
                        {
                            var figure = JsonConvert.DeserializeObject<Circle>(mystring);
                            my_figures.Add(figure);
                        }
                        if (identifier.TypeName == nameof(Lib_figures.Rectangle))
                        {
                            var figure = JsonConvert.DeserializeObject<Lib_figures.Rectangle>(mystring);
                            my_figures.Add(figure);
                        }
                    }
                } while (mystring != null);
               
                Reader.Close();
                Invalidate();
            }

        }
    }
}
