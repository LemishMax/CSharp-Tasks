using Task_3.CommandBuilders;
using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class FunctionCompositionBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var leftFunction = new AddInStorageBuilder().BuildFunction(s.Substring(0, s.IndexOf('(')));
            var rightFunction = new AddInStorageBuilder().BuildFunction(s.Substring(s.IndexOf('(') + 1, s.Length - s.IndexOf('(') - 2));
            return new FunctionComposition(leftFunction, rightFunction);
        }
    }
}
