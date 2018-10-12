namespace Task_3.FunctionBuilders
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    using Functions;

    internal class PolynomialBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var coefficients = new List<(double, int)>();
            var matches = Regex.Matches(s, "(-)?([0-9]+([,|.][0-9]+)?)?x(\\^[0-9]+)?|(-?[0-9]+([,|.][0-9]+)?)");
            foreach (var m in matches)
            {
                double value;
                int degree;
                if (m.ToString().Contains("x"))
                {
                    var values = m.ToString().Split('x');
                    switch (values[0])
                    {
                        case "":
                            value = 1;
                            break;
                        case "-":
                            value = -1;
                            break;
                        default:
                            value = Convert.ToDouble(values[0]);
                            break;
                    }

                    values[1] = values[1].Contains('^') ? values[1].Substring(1) : values[1];
                    degree = values[1] == string.Empty ? 1 : Convert.ToInt16(values[1]);
                }
                else
                {
                    value = Convert.ToDouble(m.ToString());
                    degree = 0;
                }

                var c = (value, degree);
                coefficients.Add(c);
            }

            var maxDegree = coefficients.Max(x => x.Item2);
            if (coefficients.Count <= maxDegree)
            {
                for (var i = 0; i < maxDegree; i++)
                {
                    if (coefficients.All(x => x.Item2 != i))
                    {
                        var c = (0.0, i);
                        coefficients.Add(c);
                    }
                }
            }

            coefficients.Sort((degree1, degree2) => degree1.Item2.CompareTo(degree2.Item2));
            return new Polynomial(coefficients.Select(x => x.Item1).ToList());
        }
    }
}