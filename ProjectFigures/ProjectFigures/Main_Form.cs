using System.Drawing;
//using Lib_figures;
using Core;
using Services;
using static System.Net.Mime.MediaTypeNames;
using System.IO;
using Newtonsoft.Json;
using System.Reflection;
using System.Windows.Forms;

namespace Lab1_Figures
{
    public partial class Main_Form : Form
    {
        private List<Base_Figure> my_figures;
        private List<Base_Figure_Factory> my_figures_factory;
        private List<Base_Figure> my_figures_redo;
        private Dictionary<string, Type> figureTypeMap;
        public Main_Form()
        {
            InitializeComponent();
            myPen = new Pen(Color.Black, 1);

            my_figures = new List<Base_Figure>();
            my_figures_redo = new List<Base_Figure>();
            figureTypeMap = new Dictionary<string, Type>();
            my_figures_factory = new List<Base_Figure_Factory>();
            //my_figures_factory.Add(new Lib_figures.Segment_Factory());
            //my_figures_factory.Add(new Lib_figures.Square_Factory());
            //my_figures_factory.Add(new Lib_figures.Rectangle_Factory());
            //my_figures_factory.Add(new Lib_figures.Circle_Factory());
            //my_figures_factory.Add(new Lib_figures.Ellipse_Factory());
            //my_figures_factory.Add(new Lib_figures.Polygon_Factory());
            //my_figures_factory.Add(new Lib_figures.Broken_line_Factory());
            //my_figures_factory = null;
            //figureTypeMap = null;
            SomeServices services = new SomeServices();
            services.InitializePlugins(ref my_figures_factory, ref figureTypeMap);
        }

        //Point click_position;
        Graphics graphics;
        Color pencolor = Color.Black;
        Color backcolor;
        Pen myPen = new Pen(Color.Black, 3);
        private bool is_mouse_down = false;
        Base_Figure _active_figure = null;

        private List<Point> points = new List<Point>();

        //private void InitializePlugins()
        //{
        //    try
        //    {
        //        string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        //        string pluginfolderpass = Path.Combine(startupPath, "plugins");
        //        DirectoryInfo pluginfolderinfo = new DirectoryInfo(pluginfolderpass);
        //        var plugins = pluginfolderinfo.GetFiles("*.dll");
        //        foreach (var plugin in plugins)
        //        {
        //            InitializeFactory(plugin.FullName);
        //        }
        //    }
        //    catch
        //    {

        //    }

        //}

        //private void InitializeFactory(string dllPath)
        //{
        //    //const string dllPath = "c:\\University\\OOTP\\projects_OOTP\\Lab1_Figures\\Lib_figures\\bin\\Debug\\net8.0\\Lib_figures.dll";
        //    try
        //    {
        //        // Загрузка DLL
        //        Assembly assembly = Assembly.LoadFrom(dllPath);

        //        // Получение всех типов из DLL
        //        Type[] types = assembly.GetTypes();


        //        foreach (Type type in types) // <> jeneric tipe 
        //        {
        //            var attributes = type.GetCustomAttributes();                                     

        //            if (attributes.Any(attr => attr is FigureFactoryAttribute))
        //            { // берет объект и попытается привести его к указ типу, если не удастся = null
        //                var instance = Activator.CreateInstance(type) as Base_Figure_Factory;
        //                if (instance != null)
        //                {
        //                    my_figures_factory.Add(instance);
        //                }
        //            }

        //            if (attributes.Any(attr => attr is FigureAttribute))
        //            {
        //                figureTypeMap.Add(type.Name, type);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //
        //    }

        //}

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

        private void Main_Form_MouseClick(object sender, MouseEventArgs e)
        {
            //
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            graphics.Clear(BackColor);
            my_figures.Clear();
            my_figures_redo.Clear();
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
                        try
                        {
                            var identifier = JsonConvert.DeserializeObject<Figure_Type_Identifier>(mystring);
                            if (figureTypeMap.TryGetValue(identifier.TypeName, out var figureType))
                            {
                                var figure = JsonConvert.DeserializeObject(mystring, figureType) as Base_Figure;
                                if (figure != null)
                                {
                                    my_figures.Add(figure);
                                }
                            }
                        }
                        catch
                        {
                            // ignore
                        }
                    }
                } while (mystring != null);

                Reader.Close();
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

        private Base_Figure CreateFigure(Point location)
        {
            graphics = CreateGraphics();
            string choosen_figyre = cb_figyres.SelectedItem as string;
            int corners = trackBar_corners.Value;

            Figure_Parametrs figure_parametrs = new Figure_Parametrs
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
            _active_figure = null;
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
    }
}
