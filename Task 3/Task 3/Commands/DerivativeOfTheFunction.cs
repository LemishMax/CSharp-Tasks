namespace Task_3.Commands
{
    using FunctionStorages;

    /// <inheritdoc />
    /// <summary>
    /// Данный класс управляет методом вычисления производной
    /// </summary>
    public class DerivativeOfTheFunction : ICommand
    {
        private readonly string _name;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DerivativeOfTheFunction"/>.
        /// </summary>
        /// <param name="name">Название функции</param>
        public DerivativeOfTheFunction(string name)
        {
            _name = name;
        }

        /// <summary>
        /// Обращается к методу хранилища Derivative
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        public ResultOfCommand Execute(IFunctionStorage fs)
        {
            if (!fs.IsStored(_name))
            {
                return new ResultOfCommand(false, $"{_name} не найдена");
            }

            var res = fs.Derivative(_name);
            fs.Add($"{_name}Derivative", res);
            return new ResultOfCommand(true, $"Функция добавлена в хранилище.\nПроизводная {_name} = {res}");
        }
    }
}
