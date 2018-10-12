namespace Task_3.Commands
{
    using FunctionStorages;

    /// <inheritdoc />
    /// <summary>
    /// Данный класс управляет методом удаления функции из хранилища
    /// </summary>
    public class DeleteFromStorage : ICommand
    {
        private readonly string _name;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="DeleteFromStorage"/>.
        /// </summary>
        /// <param name="name">Название функции</param>
        public DeleteFromStorage(string name)
        {
            _name = name;
        }

        /// <inheritdoc />
        /// <summary>
        /// Обращается к методу хранилища Delete 
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        public ResultOfCommand Execute(IFunctionStorage fs)
        {
            if (!fs.IsStored(_name))
            {
                return new ResultOfCommand(false, $"{_name} не найдена");
            }

            fs.Delete(_name);
            return new ResultOfCommand(true, "Функция удалена");
        }
    }
}
