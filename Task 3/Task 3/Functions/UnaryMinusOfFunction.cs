namespace Task_3.Functions
{
    using FunctionStorages;
    using Newtonsoft.Json;

    /// <inheritdoc />
    /// <summary>
    /// Класс используется для использования унарного минуса функции
    /// </summary>
    public class UnaryMinusOfFunction : Function
    {
        [JsonProperty]
        private Function _function;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="UnaryMinusOfFunction"/>.
        /// </summary>
        public UnaryMinusOfFunction(Function func)
        {
            _function = func;
        }

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет производную функции.
        /// </summary>
        /// <returns>Возвращает производную функции.</returns>
        public override Function Derivative() => _function.Derivative();

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет значение функции в заданной точке.
        /// </summary>
        /// <param name="point">Точка</param>
        /// <returns>Возвращает значение функции в заданной точке.</returns>
        public override double ValueAtPoint(double point) => _function.ValueAtPoint(-point);

        public override void ResolveReferences(IReferenceResolver referenceResolver)
        {
            var function = (ReferenceFunction)_function;
            _function = referenceResolver.Resolve(function.GetName());
        }

        /// <inheritdoc />
        /// <summary>
        /// Возращает <see cref="T:System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="T:System.String" /> которая представляет этот экземпляр.</returns>
        public override string ToString() => $"-({_function})";

        /// <inheritdoc />
        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode() => _function.GetHashCode();

        /// <inheritdoc />
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj != null && (obj.GetType() == GetType() && Equals((UnaryMinusOfFunction)obj));

        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="UnaryMinusOfFunction" /> этому экземпляру.
        /// </summary>
        /// <param name="func">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="UnaryMinusOfFunction" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        protected bool Equals(UnaryMinusOfFunction func) => _function.Equals(func._function);
    }
}
