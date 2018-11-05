namespace Task_3.Functions
{
    using FunctionStorages;

    /// <summary>
    /// Этот класс используется для работы с математическими функциями.
    /// </summary>
    public abstract class Function
    {
        /// <summary>
        /// Перегрузка оператора сложения двух функций
        /// </summary>
        /// <param name="f1">Функция 1</param>
        /// <param name="f2">Функция 2</param>
        /// <returns></returns>
        public static AdditionOfFunctions operator +(Function f1, Function f2) => new AdditionOfFunctions(f1, f2);

        /// <summary>
        /// Перегрузка оператора вычитания двух функций
        /// </summary>
        /// <param name="f1">Функция 1</param>
        /// <param name="f2">Функция 2</param>
        /// <returns></returns>
        public static SubtractionOfFunctions operator -(Function f1, Function f2) => new SubtractionOfFunctions(f1, f2);

        /// <summary>
        /// Вычисляет производную функции.
        /// </summary>
        /// <returns>Возвращает производную функции.</returns>
        public abstract Function Derivative();

        /// <summary>
        /// Вычисляет значение функции в заданной точке.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Возвращает значение функции в заданной точке.</returns>
        public abstract double ValueAtPoint(double point);

        public abstract void ResolveReferences(IReferenceResolver referenceResolver);

        /// <summary>
        /// Возращает <see cref="System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="System.String" /> которая представляет этот экземпляр.</returns>
        public abstract override string ToString();

        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public abstract override bool Equals(object obj);

        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public abstract override int GetHashCode();
    }
}
