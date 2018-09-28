using System;

    namespace Task_3.Functions
    {
        /// <inheritdoc />
        /// <summary>
        /// Этот класс используется для работы с косинусом.
        /// </summary>
        public class Cos : Function
        {
            /// <inheritdoc />
            /// <summary>
            /// Вычисляет производную косинуса.
            /// </summary>
            /// <returns>Возвращает производную косинуса.</returns>
            public override Function Derivative() => new UnaryMinusOfFunction(new Sin());

            /// <inheritdoc />
            /// <summary>
            /// Вычисляет значение косинуса в заданной точке.
            /// </summary>
            /// <param name="point"></param>
            /// <returns>Возвращает значение косинуса в заданной точке.</returns>
            public override double ValueAtPoint(double point) => Math.Cos(point);

            /// <inheritdoc />
            /// <summary>
            /// Возращает <see cref="T:System.String" /> которая представляет этот экземпляр.
            /// </summary>
            /// <returns><see cref="T:System.String" /> которая представляет этот экземпляр.</returns>
            public override string ToString() => "cos";

            /// <inheritdoc />
            /// <summary>
            /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
            /// </summary>
            /// <param name="obj">Объект для сравнения с текущим объектом.</param>
            /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
            public override bool Equals(object obj) => obj is Cos;

            /// <inheritdoc />
            /// <summary>
            /// Возвращает хэш-код для этого экземпляра.
            /// </summary>
            /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
            public override int GetHashCode() => 1;
        }
    }