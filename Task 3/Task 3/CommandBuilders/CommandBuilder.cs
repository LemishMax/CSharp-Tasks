using Task_3.Commands;

namespace Task_3.CommandBuilders
{
    /// <summary>
    /// Данный класс строит команду для взаимодействия с хранилищем функций 
    /// </summary>
    public abstract class CommandBuilder
    {
        /// <summary>
        /// Парсит строку возвращает команду для взаимодействия с хранилищем функций 
        /// </summary>
        /// <param name="line">Строка</param>
        /// <returns>Возвращает команду</returns>
        public abstract ICommand Build(string line);
    }
}
