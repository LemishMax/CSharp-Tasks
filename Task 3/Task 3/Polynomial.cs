using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    public class Polynomial
    {
        private readonly List<double> _coefficients;

        public Polynomial(IEnumerable<double> coefficients)
        {
            _coefficients = coefficients.ToList();
        }

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
                    coefficients.Add(maxDegree.ElementAt(i));
                }
            }

            return new Polynomial(coefficients);
        }

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

        public double ValueAtThePoint(double point)
        {
            return _coefficients.Select((x, i) => _coefficients.ElementAt(i) * Math.Pow(point, i)).Sum();
        }

        public Polynomial MultiplyByTheNumber(double multiplier)
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

        public Polynomial MultiplyByThePolynomial(Polynomial polynomial)
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

    }
}
