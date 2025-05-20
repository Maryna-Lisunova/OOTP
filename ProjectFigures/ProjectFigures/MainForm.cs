using System.Drawing;
//using Lib_figures;
using Core;
using Services;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

// абстр - где наследование 
// интерфейс - где общие признаки для классов

namespace Lab1_Figures
{
    public partial class MainForm : Form
    {
        private List<BaseFigure> my_figures;
        private List<BaseFigureFactory> my_figures_factory;
        private List<BaseFigure> my_figures_redo;
        private Dictionary<string, Type> figureTypeMap;
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            myPen = new Pen(Color.Black, 1);

            my_figures = new List<BaseFigure>();
            my_figures_redo = new List<BaseFigure>();
            figureTypeMap = new Dictionary<string, Type>();
            my_figures_factory = new List<BaseFigureFactory>();

            CInitializePlugins services = new CInitializePlugins();
            services.InitializePlugins(ref my_figures_factory, ref figureTypeMap);
        }

        Graphics graphics;
        Color pencolor = Color.Black;
        Color backcolor;
        Pen myPen = new Pen(Color.Black, 3);
        private bool is_mouse_down = false;
        BaseFigure _active_figure = null;

        private List<Point> points = new List<Point>();

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

            if (points.Count >= 2)
            {
                e.Graphics.DrawLines(myPen, points.ToArray());
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            my_figures.Clear();
            my_figures_redo.Clear();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            UndoRedo servicesforundo = new UndoRedo();

            if (my_figures.Any())
            {
                servicesforundo.Undo(ref my_figures, ref my_figures_redo);
                Invalidate();
            }
        }

        private void btn_redo_Click(object sender, EventArgs e)
        {
            UndoRedo servicesforredo = new UndoRedo();

            if (my_figures_redo.Any())
            {
                servicesforredo.Redo(ref my_figures, ref my_figures_redo);
                Invalidate();
            }
        }

        private void Save()
        {
            var fileDialog = new SaveFileDialog();
            var result = fileDialog.ShowDialog();
            string filename = fileDialog.FileName;

            Serialization servicesforser = new Serialization();

            if (result == DialogResult.OK)
            {
                servicesforser.WriteToFile(filename, my_figures);
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
            string filename = fileDialog.FileName;
            Serialization servicesforser = new Serialization();
            if (result == DialogResult.OK)
            {
                servicesforser.Desirialize(filename, ref my_figures, ref figureTypeMap);
                Invalidate();
            }

        }

        private void btn_pencolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            btn_pencolor.BackColor = colorDialog1.Color;
            pencolor = colorDialog1.Color;
        }

        private void btn_backcolor_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            colorDialog1.FullOpen = true;
            if (colorDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            btn_backcolor.BackColor = colorDialog1.Color;
            backcolor = colorDialog1.Color;
        }

        private BaseFigure CreateFigure(Point location)
        {
            graphics = CreateGraphics();
            string choosen_figyre = cb_figyres.SelectedItem as string;

            FigureParametrs figure_parametrs = new FigureParametrs
            {
                X = location.X,
                Y = location.Y,
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
                    return figure;
                }
            }
            return null;
        }

        private void Main_Form_MouseClick(object sender, MouseEventArgs e)
        {
            if (_active_figure != null)
            {
                if (_active_figure is IArbitrary arbitrary)
                {
                    arbitrary.Continue(e.X, e.Y);
                    Invalidate();
                }
            }
        }

        private void Main_Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (_active_figure == null)
            {
                _active_figure = CreateFigure(e.Location);
            }
            else
            {
                // что то делаем с активной фигурой
            }

            Invalidate();
        }

        private void Main_Form_MouseUp(object sender, MouseEventArgs e)
        {
            if (_active_figure is IResizeable resizeable)
            {
                _active_figure = null;
            }
        }


        private void Main_Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (_active_figure != null)
            {
                // проверяет реализует ли фигура интерфейс ресайз
                if (_active_figure is IResizeable resizeable)
                {
                    resizeable.Resize(e.X, e.Y);
                    Invalidate();
                }
            }
        }

        private void Main_Form_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (_active_figure is IArbitrary arbitrary)
            {
                arbitrary.Stop(e.X, e.Y);
                _active_figure = null;
                Invalidate();
            }
        }

        private void btn_add_plugin_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;

            CInitializePlugins services = new CInitializePlugins();
            services.InitializePlugins(ref my_figures_factory, ref figureTypeMap, filename);

            cb_figyres.Items.Clear();
            foreach (var figure in my_figures_factory)
            {
                cb_figyres.Items.Add(figure.Name);
            }
        }
    }
}
