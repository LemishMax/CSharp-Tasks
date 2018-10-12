namespace Task_3
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using CommandBuilders;
    using FunctionStorages;

    /// <summary>
    /// Данный класс парсит пользовательский ввод и применяет его к хранилищу
    /// </summary>
    public class Interpreter
    {
        private readonly IFunctionStorage _functionStorage;

        private readonly Dictionary<string, CommandBuilder> _commands;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Interpreter"/>.
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <param name="commands">Список команд взаимодействия с хранилищем</param>
        public Interpreter(IFunctionStorage fs, Dictionary<string, CommandBuilder> commands)
        {
            _functionStorage = fs;
            _commands = commands;
        }

        /// <summary>
        /// Парсит строку и применяет команду к хранилищу
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Возвращает результат работы</returns>
        public string Parse(string s)
        {
            var builder = _commands.FirstOrDefault(x => Regex.IsMatch(s, x.Key)).Value;
            return builder == null
                ? "Команда не найдена"
                : builder.Build(s)?.Execute(_functionStorage).Message;
        }
    }
}