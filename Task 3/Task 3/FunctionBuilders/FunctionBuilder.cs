namespace Task_3.FunctionBuilders
{
    using Functions;

    /// <summary>
    /// Данный класс создает объекты класса <c>Function</c>
    /// </summary>
    public abstract class FunctionBuilder
    {
        /// <summary>
        /// Парсит строку, возвращает обьект <c>Function</c>
        /// </summary>
        /// <param name="s">Строка</param>
        /// <returns>Возвращает обьект <c>Function</c></returns>
        public abstract Function Build(string s);
    }
}
