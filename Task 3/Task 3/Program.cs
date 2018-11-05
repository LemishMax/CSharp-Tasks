namespace Task_3
{
    using System.Configuration;
    using System.IO;
    using Castle.Windsor;
    using CommandBuilders;
    using FunctionStorages;

    /// <summary>
    /// Основной класс.
    /// </summary>
    public class Program
    {
        private static void Main()
        {
            Logger.InitLogger();
            var serializer = new Serializer();
            var container = new WindsorContainer();
            container.Install(new IoCInstaller());
            var json = ConfigurationManager.AppSettings["Json"];
            if (!File.Exists(json))
            {
                using (File.Create(json))
                {
                }
            }

            var functionStorage = container.Resolve<IFunctionStorage>();
            var buildersOfCommands = container.Resolve<BuildersOfCommands>().GetBuilders();
            var interpreter = new Interpreter(functionStorage, buildersOfCommands);
            new Runner(serializer, functionStorage, interpreter).Run();
        }
    }
}