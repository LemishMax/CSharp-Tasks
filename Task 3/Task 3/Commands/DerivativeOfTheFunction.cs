using Task_3.FunctionStorages;

namespace Task_3.Commands
{
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
        public string Execute(IFunctionStorage fs)
        {
            if (!fs.IsStored(_name))
            {
                return $"{_name} не найдена";
            }

            var res = fs.Derivative(_name);
            fs.Add($"{_name}Derivative", res);
            return $"Функция добавлена в хранилище.\nПроизводная {_name} = {res}";
        }
    }
}
