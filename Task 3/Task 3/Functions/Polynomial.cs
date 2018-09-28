using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3.Functions
{
    /// <inheritdoc />
    /// <summary>
    /// Этот класс используется для работы с многочленом.
    /// </summary>
    public class Polynomial : Function
    {
        private readonly List<double> _coefficients;

        /// <summary>
        /// Переопределение оператора +.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Возвращает новый многочлен основанный на сумме соотвествующих коэффициентов двух многочленов.</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            return p1.Add(p2);
        }

        /// <summary>
        /// Переопределение оператора -.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Возвращает новый многочлен основанный на разности соотвествующих коэффициентов двух многочленов.</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return p1.Subtract(p2);
        }

        /// <summary>
        /// Переопределение оператора ==.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Сравнивает два многочлена, если соотвестующие коэффициенты равны возвращает true, иначе - false.</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2) => p1.Equals(p2);

        /// <summary>
        /// Переопределение оператора !=.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Сравнивает два многочлена, если соотвестующие коэффициенты равны возвращает false, иначе - true.</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2) => !p1.Equals(p2);

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Polynomial"/>.
        /// </summary>
        /// <param name="coefficients">Принимает список коэффициентов.</param>
        public Polynomial(IEnumerable<double> coefficients) => _coefficients = coefficients.ToList();

        /// <summary>
        /// Сложение двух многочленов.
        /// </summary>
        /// <param name="summand">Слагаемое.</param>
        /// <returns>Возвращает новый многочлен основанный на сумме соотвествующих коэффициентов двух многочленов.</returns>
        public Polynomial Add(Polynomial summand)
        {
            var coefficients = new List<double>();
            var minDegree = Math.Min(_coefficients.Count, summand._coefficients.Count);
            var polynomialWithGreaterDegree = _coefficients.Count > summand._coefficients.Count
                ? _coefficients
                : summand._coefficients;
            for (var i = 0; i < polynomialWithGreaterDegree.Count; i++)
            {
                if (i < minDegree)
                {
                    coefficients.Add(_coefficients[i] + summand._coefficients[i]);
                }
                else
                {
                    coefficients.Add(polynomialWithGreaterDegree[i]);
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Вычитание двух многочленов.
        /// </summary>
        /// <param name="subtrahend">Вычитаемое.</param>
        /// <returns>Возвращает новый многочлен основанный на разности соотвествующих коэффициентов двух многочленов.</returns>
        public Polynomial Subtract(Polynomial subtrahend)
        {
            var coefficients = new List<double>();
            var minDegree = Math.Min(_coefficients.Count, subtrahend._coefficients.Count);
            var polynomialWithGreaterDegree = _coefficients.Count > subtrahend._coefficients.Count
                ? _coefficients
                : subtrahend._coefficients;
            for (var i = 0; i < polynomialWithGreaterDegree.Count; i++)
            {
                if (i < minDegree)
                {
                    coefficients.Add(_coefficients[i] - subtrahend._coefficients[i]);
                }
                else
                {
                    coefficients.Add(polynomialWithGreaterDegree == subtrahend._coefficients
                        ? -polynomialWithGreaterDegree.ElementAt(i)
                        : polynomialWithGreaterDegree.ElementAt(i));
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Умножение многочлена на число.
        /// </summary>
        /// <param name="multiplier">Множитель.</param>
        /// <returns>Возвращает новый многочлен основанный на умножении коэффициентов на заданный множитель.</returns>
        public Polynomial Multiply(double multiplier) => multiplier == 0
            ? new Polynomial(new List<double>())
            : new Polynomial(_coefficients.Select(x => x * multiplier).ToList());

        /// <summary>
        /// Умножение многочлена на многочлен.
        /// </summary>
        /// <param name="polynomial">Многочлен.</param>
        /// <returns>Возвращает новый многочлен основанный на умножении коэффициентов первого многочлена на коэффициенты второго многочлена.</returns>
        public Polynomial Multiply(Polynomial polynomial)
        {
            var coefficients = new List<double>();
            for (var i = 0; i < _coefficients.Count; i++)
            {
                for (var j = 0; j < polynomial._coefficients.Count; j++)
                {
                    if (coefficients.Count <= i + j)
                    {
                        coefficients.Add(_coefficients[i] * polynomial._coefficients[j]);
                    }
                    else
                    {
                        coefficients[i + j] += _coefficients[i] * polynomial._coefficients[j];
                    }
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Нахождение корня многочлена на заданном промежутке.
        /// </summary>
        /// <param name="startInterval">Начало интервала.</param>
        /// <param name="endInterval">Конец интервала.</param>
        /// <param name="epsilon">Эпсилон.</param>
        /// <returns>Возвращает корень многочлена на заданном промежутке.</returns>
        public double FindRoot(double startInterval, double endInterval, double epsilon)
        {
            double root;
            while (endInterval - startInterval > epsilon)
            {
                root = (startInterval + endInterval) / 2;
                if (ValueAtPoint(startInterval) * ValueAtPoint(root) <= 0)
                {
                    endInterval = root;
                }
                else
                {
                    startInterval = root;
                }
            }

            root = (startInterval + endInterval) / 2;
            return root;
        }

        /// <inheritdoc />
        public override double ValueAtPoint(double point) => _coefficients.Select((x, i) => _coefficients[i] * Math.Pow(point, i)).Sum();

        /// <inheritdoc />
        public override Function Derivative()
        {
            var coefficients = new List<double>();
            for (var i = 1; i < _coefficients.Count; i++)
            {
                coefficients.Add(_coefficients[i] * i);
            }

            return new Polynomial(coefficients);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            var polynomial = "";
            for (var i = _coefficients.Count - 1; i >= 0; i--)
            {
                if (i != _coefficients.Count - 1 && _coefficients[i] > 0.0)
                {
                    polynomial += "+";
                }

                if (_coefficients[i] != 0 && (_coefficients[i] != 1 || i == 0))
                {
                    polynomial += _coefficients[i] == -1
                        ? "-"
                        : _coefficients[i].ToString();
                    polynomial += i == 0 && _coefficients[i] == -1 ? "1" : "";
                }

                if (_coefficients[i] != 0 && i > 0)
                {
                    polynomial += "x" + (i > 1 ? "^" + i : string.Empty);
                }
            }

            return polynomial;
        }

        /// <summary>
        /// Получение степени многочлена.
        /// </summary>
        /// <returns>Возвращает степень многочлена.</returns>
        public int GetDegree()
        {
            return _coefficients.Count <= 1 ? 0 : _coefficients.Count - 1;
        }

        /// <inheritdoc />
        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode()
        {
            return _coefficients != null ? _coefficients.GetHashCode() : 0;
        }


        /// <inheritdoc />
        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref="T:System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref="T:System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj) => obj != null && (obj.GetType() == GetType() && Equals((Polynomial)obj));

        /// <summary>
        /// Сравнивает два многочлена, если соотвестующие коэффициенты равны возвращает true, иначе - false.
        /// </summary>
        /// <param name="other">Другой многочлен.</param>
        /// <returns><c>true</c> если соотвестующие коэффициенты равны, <c>false</c> если нет.</returns>
        protected bool Equals(Polynomial other)
        {
            if (_coefficients == other._coefficients)
            {
                return true;
            }

            var lessCoefficients =
                _coefficients.Count <= other._coefficients.Count ? _coefficients : other._coefficients;
            var moreCoefficients =
                _coefficients.Count > other._coefficients.Count ? _coefficients : other._coefficients;
            for (var i = lessCoefficients.Count; i < moreCoefficients.Count; i++)
            {
                lessCoefficients.Add(0.0);
            }
            return lessCoefficients.SequenceEqual(moreCoefficients);
        }
    }
}
