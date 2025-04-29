using System.Reflection;
using Core;

namespace Services
{
    public class SomeServices
    {
        private void InitializeFactory(string dllPath, ref List<Base_Figure_Factory> my_figures_factory, ref Dictionary<string, Type> figureTypeMap)
        {
            //const string dllPath = "c:\\University\\OOTP\\projects_OOTP\\Lab1_Figures\\Lib_figures\\bin\\Debug\\net8.0\\Lib_figures.dll";
            try
            {
                // Загрузка DLL
                Assembly assembly = Assembly.LoadFrom(dllPath);

                // Получение всех типов из DLL
                Type[] types = assembly.GetTypes();


                foreach (Type type in types) // <> jeneric tipe 
                {
                    var attributes = type.GetCustomAttributes();

                    if (attributes.Any(attr => attr is FigureFactoryAttribute))
                    { // берет объект и попытается привести его к указ типу, если не удастся = null
                        var instance = Activator.CreateInstance(type) as Base_Figure_Factory;
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

        public void InitializePlugins(ref List<Base_Figure_Factory> my_figures_factory, ref Dictionary<string, Type> figureTypeMap)
        {
            try
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
            catch
            {

            }

        }


    }
}
