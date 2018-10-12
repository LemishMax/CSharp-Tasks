namespace Task_3.Commands
{
    using FunctionStorages;

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
        ResultOfCommand Execute(IFunctionStorage fs);
    }
}
