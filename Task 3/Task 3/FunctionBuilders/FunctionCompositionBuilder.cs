namespace Task_3.FunctionBuilders
{
    using System;
    using Functions;

    internal class FunctionCompositionBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var leftFunction = new ReferenceFunction(s.Substring(0, s.IndexOf("(", StringComparison.Ordinal)));
            var rightFunction = new ReferenceFunction(s.Substring(s.IndexOf('(') + 1, s.Length - s.IndexOf('(') - 2));
            return new FunctionComposition(leftFunction, rightFunction);
        }
    }
}
