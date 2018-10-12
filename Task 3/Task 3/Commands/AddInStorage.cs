namespace Task_3.Commands
{
    using Functions;
    using FunctionStorages;

    /// <inheritdoc />
    /// <summary>
    /// Данный класс управляет методом добавления функции в хранилище
    /// </summary>
    public class AddInStorage : ICommand
    {
        private readonly string _name;

        private readonly Function _function;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="AddInStorage"/>.
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <param name="func">Функция</param>
        public AddInStorage(string name, Function func)
        {
            _name = name;
            _function = func;
        }

        /// <inheritdoc />
        /// <summary>
        /// Обращается к методу хранилища Add 
        /// </summary>
        /// <param name="fs">Храенилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        public ResultOfCommand Execute(IFunctionStorage fs)
        {
            if (fs.IsStored(_name))
            {
                return new ResultOfCommand(false, $"{_name} уже используется");
            }

            _function.ResolveReferences(new ReferenceResolver(fs));

            fs.Add(_name, _function);
            return new ResultOfCommand(true, "Функция добавлена");
        }
    }
}
