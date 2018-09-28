using Task_3.CommandBuilders;
using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class UnaryMinusOfFunctionBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var func = new AddInStorageBuilder().BuildFunction(s.Substring(s.IndexOf('(') + 1, s.Length - s.IndexOf('(') - 2));
            return new UnaryMinusOfFunction(func);
        }
    }
}