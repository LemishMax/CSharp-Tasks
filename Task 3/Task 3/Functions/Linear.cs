using System.Globalization;

namespace Task_3.Functions
{
    /// <inheritdoc />
    /// <summary>
    /// Этот класс используется для работы с линейной функцией.
    /// </summary>
    public class Linear : Function
    {
        private readonly double _k, _b;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Linear"/>.
        /// </summary>
        public Linear(double k, double b)
        {
            _k = k;
            _b = b;
        }

        /// <inheritdoc />
        /// <summary> 
        /// Вычисляет производную линейной функции.
        /// </summary>
        /// <returns>Возвращает производную линейной функции.</returns>
        public override Function Derivative()
        {
            return new Linear(0, _k);
        }

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет значение лийнейной функции в заданной точке.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Возвращает значение лийнейной функции в заданной точке.</returns>
        public override double ValueAtPoint(double point)
        {
            return _k * point + _b;
        }

        /// <inheritdoc />
        /// <summary>
        /// Возращает <see cref="T:System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="T:System.String" /> которая представляет этот экземпляр.</returns>
        public override string ToString()
        {
            var linear = "";
            linear += _k == 1 || _k == 0 ? "" : _k.ToString(CultureInfo.InvariantCulture);
            linear += _k == 0 ? "" : "x";
            linear += _b == 0 ? "" : _b > 0 && _k != 0 ? "+" + _b : _b.ToString(CultureInfo.InvariantCulture);
            return linear == "" ? "0" : linear;
        }

        /// <inheritdoc />
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is Linear that && (_k.Equals(that._k) && _b.Equals(that._b));

        /// <inheritdoc />
        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return (_k.GetHashCode() * 115) ^ _b.GetHashCode();
            }
        }
    }
}
