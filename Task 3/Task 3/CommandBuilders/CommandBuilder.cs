namespace Task_3.CommandBuilders
{
    using Commands;

    /// <summary>
    /// Данный класс строит команду для взаимодействия с хранилищем функций 
    /// </summary>
    public abstract class CommandBuilder
    {
        public abstract ICommand Build(string line);
    }
}
