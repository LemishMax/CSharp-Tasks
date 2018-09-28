namespace Task_3.Functions
{
    /// <inheritdoc />
    /// <summary>
    /// Класс используется для создания композиции функций
    /// </summary>
    public class FunctionComposition : Function
    {
        private readonly Function _leftFunction;
        private readonly Function _rightFunction;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="FunctionComposition"/>.
        /// </summary>
        public FunctionComposition(Function leftFunction, Function rightFunction)
        {
            _leftFunction = leftFunction;
            _rightFunction = rightFunction;
        }

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет производную функции.
        /// </summary>
        /// <returns>Возвращает производную функции.</returns>
        public override Function Derivative() => new FunctionComposition(_leftFunction.Derivative(), _rightFunction.Derivative());

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет значение функции в заданной точке.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Возвращает значение функции в заданной точке.</returns>
        public override double ValueAtPoint(double point) =>
            _leftFunction.ValueAtPoint(_rightFunction.ValueAtPoint(point));

        /// <inheritdoc />
        /// <summary>
        /// Возращает <see cref="T:System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="T:System.String" /> которая представляет этот экземпляр.</returns>
        public override string ToString() => $"{_leftFunction}({_rightFunction})";

        /// <inheritdoc />
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj != null && (obj.GetType() == GetType() && Equals((FunctionComposition)obj));
        
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="SubtractionOfFunctions" /> этому экземпляру.
        /// </summary>
        /// <param name="func">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="SubtractionOfFunctions" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        protected bool Equals(FunctionComposition func) => Equals(_leftFunction, func._leftFunction) && Equals(_rightFunction, func._rightFunction);

        /// <inheritdoc />
        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode() => _leftFunction.GetHashCode() + _leftFunction.GetHashCode();
    }
}
