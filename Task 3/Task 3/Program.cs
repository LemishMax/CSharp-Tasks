namespace Task_3
{
    using System;
    using System.IO;
    using Commands;
    using FunctionStorages;

    /// <summary>
    /// Основной класс.
    /// </summary>
    public class Program
    {
        private const string Json = @"FunctionsStorage.json";

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

            var functionStorage = new FunctionStorageDecorator(serializer.Deserialize(File.ReadAllText(Json)));

            var interpreter = new Interpreter(functionStorage, new BuildersOfCommandsForFunctionStorage().GetBuilders());

            var command = string.Empty;
            new System.Threading.Timer(
               e => { File.WriteAllText(Json, serializer.Serialize(functionStorage.GetFunctionStorage())); }, null, TimeSpan.Zero, TimeSpan.FromMinutes(3));
            while (command != "exit")
            {
                command = Console.ReadLine();
                if (command == "s")
                {
                    File.WriteAllText(Json, serializer.Serialize(functionStorage.GetFunctionStorage()));
                    Console.WriteLine("Функции сохранены");
                }
                else
                {
                    Console.WriteLine(interpreter.Parse(command));
                }
            }

            File.WriteAllText(Json, serializer.Serialize(functionStorage.GetFunctionStorage()));
        }
    }
}