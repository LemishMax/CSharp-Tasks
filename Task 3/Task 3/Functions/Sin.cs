using System;

namespace Task_3.Functions
{
    /// <inheritdoc />
    /// <summary>
    /// Этот класс используется для работы с синусом.
    /// </summary>
    public class Sin : Function
    {
        /// <inheritdoc />
        /// <summary>
        /// Вычисляет производную синуса.
        /// </summary>
        /// <returns>Возвращает производную синуса.</returns>
        public override Function Derivative() => new Cos();

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет значение синуса в заданной точке.
        /// </summary>
        /// <param name="point"></param>
        /// <returns>Возвращает значение синуса в заданной точке.</returns>
        public override double ValueAtPoint(double point) => Math.Sin(point);

        /// <inheritdoc />
        /// <summary>
        /// Возращает <see cref="T:System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="T:System.String" /> которая представляет этот экземпляр.</returns>
        public override string ToString() => "sin";

        /// <inheritdoc />
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj is Sin;

        /// <inheritdoc />
        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode() => 1;
    }
}
