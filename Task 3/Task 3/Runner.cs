namespace Task_3
{
    using System;
    using System.Configuration;
    using System.IO;
    using System.Timers;
    using FunctionStorages;

    public class Runner
    {
        private readonly Serializer _serializer;
        private readonly IFunctionStorage _functionStorage;
        private readonly Interpreter _interpreter;
        private readonly string _json = ConfigurationManager.AppSettings["Json"];
        private readonly Timer _timer = new Timer(180000);
        
        public Runner(Serializer serializer, IFunctionStorage functionStorage, Interpreter interpreter)
        {
            _serializer = serializer;
            _functionStorage = functionStorage;
            _interpreter = interpreter;
        }

        public void Run()
        {
            _timer.Elapsed += SaveStorage;
            _timer.Start();
            Console.WriteLine("Данная программа работает с математическими функциями. Более подробно можно ознакомиться в файле README.MD.\n" +
                              "Чтобы сохранить функции введите ‘s’;\n" +
                              "Чтобы завершить программу с сохранением введите ‘exit’;");
            var command = string.Empty;
            while (command != "exit")
            {
                command = Console.ReadLine();
                if (command == "s")
                {
                    File.WriteAllText(_json, _serializer.Serialize(_functionStorage.GetStorage()));
                    Console.WriteLine("Функции сохранены");
                }

                Console.WriteLine(_interpreter.Parse(command));
            }
            File.WriteAllText(_json, _serializer.Serialize(_functionStorage.GetStorage()));
            _timer.Stop();
            _timer.Dispose();
        }

        public void SaveStorage(object sender, ElapsedEventArgs e)
        {
            File.WriteAllText(_json, _serializer.Serialize(_functionStorage.GetStorage()));
        }
    }
}
