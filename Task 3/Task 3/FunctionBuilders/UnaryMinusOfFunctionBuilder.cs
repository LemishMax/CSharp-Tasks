namespace Task_3.FunctionBuilders
{
    using Functions;

    internal class UnaryMinusOfFunctionBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var func = new ReferenceFunction(
                s.Substring(s.IndexOf('(') + 1, s.Length - s.IndexOf('(') - 2));
            return new UnaryMinusOfFunction(func);
        }
    }
}