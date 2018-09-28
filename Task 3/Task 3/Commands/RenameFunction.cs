using Task_3.FunctionStorages;

namespace Task_3.Commands
{
    /// <inheritdoc />
    /// <summary>
    /// Данный класс управляет методом переименования функции
    /// </summary>
    public class RenameFunction:ICommand
    {
        private readonly string _oldName;

        private readonly string _newName;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="RenameFunction"/>.
        /// </summary>
        /// <param name="oldName">Текущее название</param>
        /// <param name="newName">Новое название</param>
        public RenameFunction(string oldName, string newName)
        {
            _oldName = oldName;
            _newName = newName;
        }

        /// <inheritdoc />
        /// <summary>
        /// Обращается к методу хранилища Rename
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        public string Execute(IFunctionStorage fs)
        {
            if (!fs.IsStored(_oldName))
            {
                return $"{_oldName} не найдена";
            }

            if (fs.IsStored(_newName))
            {
                return $"{_newName} используется";
            }

            fs.Rename(_oldName, _newName);
            return "Функция перименована";
        }
    }
}
