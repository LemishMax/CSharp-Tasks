namespace Task_3
{
    using System;
    using System.Configuration;
    using System.IO;
    using Castle.MicroKernel.Registration;
    using Castle.Windsor;
    using CommandBuilders;
    using FunctionBuilders;
    using FunctionStorages;

    /// <summary>
    /// Основной класс.
    /// </summary>
    public class Program
    {
        private static readonly string Json = ConfigurationManager.AppSettings["Json"];

        private static void Main()
        {
            Console.WriteLine("Данная программа работает с математическими функциями. Более подробно можно ознакомиться в файле README.MD.\n" +
            "Чтобы сохранить функции введите ‘s’;\n" +
            "Чтобы завершить программу с сохранением введите ‘exit’;");
            Logger.InitLogger();

            var serializer = new Serializer();
            if (!File.Exists(Json))
            {
                File.Create(Json);
            }

            var container = new WindsorContainer();

            container.Register(Component.For<BaseBuildersOfFunctions>().ImplementedBy<BuildersOfFunctions>());
            var buildersOfFunctions = container.Resolve<BaseBuildersOfFunctions>();

            container.Register(Component.For<IFunctionStorage>().ImplementedBy<FunctionStorageDecorator>().DynamicParameters(
                (r, k) =>
                {
                    k["functionStorage"] = new FunctionStorage(serializer.Deserialize(File.ReadAllText(Json)));
                }));
            var buildersOfCommands = container.Resolve<BuildersOfCommands>().GetBuilders();

            container.Register(Component.For<BuildersOfCommands>().ImplementedBy<BuildersOfCommandsForFunctionStorage>()
                .DynamicParameters((r, k) => { k["buildersOfFunctions"] = buildersOfFunctions.GetFunctions(); }));
            var functionStorage = container.Resolve<IFunctionStorage>();

            var interpreter = new Interpreter(functionStorage, buildersOfCommands);
            var command = string.Empty;
            new System.Threading.Timer(
               e => { File.WriteAllText(Json, serializer.Serialize(functionStorage.GetStorage())); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
            while (command != "exit")
            {
                command = Console.ReadLine();
                if (command == "s")
                {
                    File.WriteAllText(Json, serializer.Serialize(functionStorage.GetStorage()));
                    Console.WriteLine("Функции сохранены");
                }
                else
                {
                    Console.WriteLine(interpreter.Parse(command));
                }
            }

            File.WriteAllText(Json, serializer.Serialize(functionStorage.GetStorage()));
        }
    }
}