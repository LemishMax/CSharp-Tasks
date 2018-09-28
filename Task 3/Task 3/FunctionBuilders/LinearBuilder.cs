using System;
using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class LinearBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            double k;
            var z = s.Split('x');
            switch (z[0])
            {
                case "":
                    k = 1;
                    break;
                case "-":
                    k = -1;
                    break;
                default:
                    k = Convert.ToDouble(z[0]);
                    break;
            }
            var b = z[1] == "" ? 0 : Convert.ToDouble(z[1]);
            return new Linear(k, b);
        }
    }
}
