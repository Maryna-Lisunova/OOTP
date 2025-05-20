using System.Reflection;
using Core;

namespace Services
{
    public class CInitializePlugins
    {
        private void InitializeFactory(string dllPath, ref List<BaseFigureFactory> my_figures_factory, ref Dictionary<string, Type> figureTypeMap)
        {            
            try
            {
                // загрузка DLL
                Assembly assembly = Assembly.LoadFrom(dllPath);

                // получение всех типов из DLL
                Type[] types = assembly.GetTypes();


                foreach (Type type in types) // <> jeneric tipe 
                {
                    var attributes = type.GetCustomAttributes();

                    if (attributes.Any(attr => attr is FigureFactoryAttribute))
                    { // берет объект и попытается привести его к указ типу, если не удастся = null
                        var instance = Activator.CreateInstance(type) as BaseFigureFactory;
                        if (instance != null)
                        {
                            my_figures_factory.Add(instance);
                        }
                    }

                    if (attributes.Any(attr => attr is FigureAttribute))
                    {
                        figureTypeMap.Add(type.Name, type);
                    }
                }
            }
            catch (Exception ex)
            {
                //
            }

        }

        public void InitializePlugins(ref List<BaseFigureFactory> my_figures_factory, ref Dictionary<string, Type> figureTypeMap, string filepath = "")
        {
            try
            { 
                if (filepath == "")
                {
                    string startupPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    string pluginfolderpass = Path.Combine(startupPath, "plugins");
                    DirectoryInfo pluginfolderinfo = new DirectoryInfo(pluginfolderpass);
                    var plugins = pluginfolderinfo.GetFiles("*.dll");
                    foreach (var plugin in plugins)
                    {
                        InitializeFactory(plugin.FullName, ref my_figures_factory, ref figureTypeMap);
                    }
                }
                else
                {
                    InitializeFactory(filepath, ref my_figures_factory, ref figureTypeMap);
                }                
            }
            catch
            {
                // ignore;
            }
        }
    }
}
