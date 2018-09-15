using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    /// <summary>
    /// Этот класс используется для работы с многочленом.
    /// </summary>
    public class Polynomial
    {
        private readonly List<double> _coefficients;

        /// <summary>
        /// Перезагрузка оператора +.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Возвращает новый многочлен основанный на сумме соотвествующих коэффициентов двух многочленов.</returns>
        public static Polynomial operator +(Polynomial p1, Polynomial p2)
        {
            return p1.Add(p2);
        }

        /// <summary>
        /// Перезагрузка оператора -.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Возвращает новый многочлен основанный на разности соотвествующих коэффициентов двух многочленов.</returns>
        public static Polynomial operator -(Polynomial p1, Polynomial p2)
        {
            return p1.Subtract(p2);
        }

        /// <summary>
        /// Перезагрузка оператора ==.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Сравнивает два многочлена, если соотвестующие коэффициенты равны возвращает true, иначе - false.</returns>
        public static bool operator ==(Polynomial p1, Polynomial p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Перезагрузка оператора !=.
        /// </summary>
        /// <param name="p1">Первый многочлен.</param>
        /// <param name="p2">Второй многочлен.</param>
        /// <returns>Сравнивает два многочлена, если соотвестующие коэффициенты равны возвращает false, иначе - true.</returns>
        public static bool operator !=(Polynomial p1, Polynomial p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Polynomial"/>.
        /// </summary>
        /// <param name="coefficients">Принимает список коэффициентов.</param>
        public Polynomial(IEnumerable<double> coefficients)
        {
            _coefficients = coefficients.ToList();
        }

        /// <summary>
        /// Сложение двух многочленов.
        /// </summary>
        /// <param name="summand">Слагаемое.</param>
        /// <returns>Возвращает новый многочлен основанный на сумме соотвествующих коэффициентов двух многочленов.</returns>
        public Polynomial Add(Polynomial summand)
        {
            var coefficients = new List<double>();
            var minDegree = Math.Min(_coefficients.Count, summand._coefficients.Count);
            var maxDegree = _coefficients.Count > summand._coefficients.Count
                ? _coefficients
                : summand._coefficients;
            for (var i = 0; i < maxDegree.Count; i++)
            {
                if (i < minDegree)
                {
                    coefficients.Add(_coefficients.ElementAt(i) + summand._coefficients.ElementAt(i));
                }
                else
                {
                    coefficients.Add(maxDegree.ElementAt(i));
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
            var maxDegree = _coefficients.Count > subtrahend._coefficients.Count
                ? _coefficients
                : subtrahend._coefficients;
            for (var i = 0; i < maxDegree.Count; i++)
            {
                if (i < minDegree)
                {
                    coefficients.Add(_coefficients.ElementAt(i) - subtrahend._coefficients.ElementAt(i));
                }
                else
                {

                    coefficients.Add(maxDegree == subtrahend._coefficients ? -maxDegree.ElementAt(i) : maxDegree.ElementAt(i));
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Умножение многочлена на число.
        /// </summary>
        /// <param name="multiplier">Множитель.</param>
        /// <returns>Возвращает новый многочлен основанный на умножении коэффициентов на заданный множитель.</returns>
        public Polynomial Multiply(double multiplier)
        {
            var coefficients = new List<double>();
            if (multiplier != 0)
            {
                foreach (var d in _coefficients)
                {
                    coefficients.Add(d * multiplier);
                }
            }

            return new Polynomial(coefficients);
        }

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
                        coefficients.Add(_coefficients.ElementAt(i) * polynomial._coefficients.ElementAt(j));
                    }
                    else
                    {
                        coefficients[i + j] += _coefficients.ElementAt(i) * polynomial._coefficients.ElementAt(j);
                    }
                }
            }

            return new Polynomial(coefficients);
        }

        /// <summary>
        /// Вычисляет значение многочлена в заданной точке.
        /// </summary>
        /// <param name="point">Точка.</param>
        /// <returns>Возвращает значение многочлена в заданной точке.</returns>
        public double ValueAtThePoint(double point)
        {
            return _coefficients.Select((x, i) => _coefficients.ElementAt(i) * Math.Pow(point, i)).Sum();
        }

        /// <summary>
        /// Нахождение корня многочлена на заданном промежутке.
        /// </summary>
        /// <param name="startInterval">Начало интервала.</param>
        /// <param name="endInterval">Конец интервала.</param>
        /// <param name="epsilon">Эпсилон.</param>
        /// <returns>Возвращает корень многочлена на заданном промежутке.</returns>
        public double RootFinding(double startInterval, double endInterval, double epsilon)
        {
            double root;
            while (endInterval - startInterval > epsilon)
            {
                root = (startInterval + endInterval) / 2;
                if (ValueAtThePoint(startInterval) * ValueAtThePoint(root) <= 0)
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

        /// <summary>
        /// Возращает <see cref="System.String" /> которая представляет этот экземпляр.
        /// </summary>
        /// <returns><see cref="System.String" /> которая представляет этот экземпляр.</returns>
        public override string ToString()
        {
            var polynomial = "";
            for (var i = _coefficients.Count - 1; i >= 0; i--)
            {
                if (i != _coefficients.Count - 1 && _coefficients.ElementAt(i) > 0.0)
                {
                    polynomial += "+";
                }

                if (_coefficients.ElementAt(i) != 0 && (_coefficients.ElementAt(i) != 1 || i == 0))
                {
                    polynomial += _coefficients.ElementAt(i) == -1
                        ? "-"
                        : _coefficients.ElementAt(i).ToString();
                    polynomial += i == 0 && _coefficients.ElementAt(i) == -1 ? "1" : "";
                }

                if (_coefficients.ElementAt(i) != 0 && i > 0)
                {
                    polynomial += "x" + ((i > 1) ? "^" + i : string.Empty);
                }
            }

            return polynomial;
        }

        /// <summary>
        /// Возвращает хэш-код для этого экземпляра.
        /// </summary>
        /// <returns>Хэш-код для этого экземпляра, подходящий для использования в хэширующих алгоритмах и структурах данных, таких как хеш-таблица</returns>
        public override int GetHashCode()
        {
            return _coefficients != null ? _coefficients.GetHashCode() : 0;
        }

        /// <summary>
        /// Определяет, соответствует ли указанный экземпляр <see cref = "System.Object" /> этому экземпляру.
        /// </summary>
        /// <param name="obj">Объект для сравнения с текущим объектом.</param>
        /// <returns><c>true</c>если указанный <see cref = "System.Object" /> равен этому экземпляру; в противном случае, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Polynomial)obj);
        }

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
