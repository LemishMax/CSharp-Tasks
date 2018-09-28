using Task_3.FunctionStorages;

namespace Task_3.Commands
{
    /// <summary>
    /// Данный класс управляет методами хранилища функций
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Обращается к методу хранилища функций
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        string Execute(IFunctionStorage fs);
    }
}
