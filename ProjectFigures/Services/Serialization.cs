using Core;
using Newtonsoft.Json;

namespace Services
{
    public class Serialization
    {
        public void WriteToFile(string filename, List<BaseFigure> my_figures)
        {
            StreamWriter Writer = new StreamWriter(filename);
            foreach (var figure in my_figures)
            {
                string json = JsonConvert.SerializeObject(figure);
                Writer.WriteLine(json);
            }
            Writer.Close();
        }

        public void Desirialize(string filename, ref List<BaseFigure> my_figures, ref Dictionary<string, Type> figureTypeMap)
        {
            my_figures.Clear();

            StreamReader Reader = new StreamReader(filename);
            string mystring;
            do
            {
                mystring = Reader.ReadLine();
                if (mystring != null)
                {
                    try
                    {
                        var identifier = JsonConvert.DeserializeObject<FigureTypeIdentifier>(mystring);
                        if (figureTypeMap.TryGetValue(identifier.TypeName, out var figureType))
                        {
                            var figure = JsonConvert.DeserializeObject(mystring, figureType) as BaseFigure;
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
        }
    }
}
