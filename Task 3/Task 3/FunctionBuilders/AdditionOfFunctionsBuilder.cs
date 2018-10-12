namespace Task_3.FunctionBuilders
{
    using System;
    using Functions;

    internal class AdditionOfFunctionsBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var leftFunction = new ReferenceFunction(s.Substring(0, s.IndexOf(" + ", StringComparison.Ordinal)));
            var rightFunction = new ReferenceFunction(s.Substring(s.IndexOf(" + ", StringComparison.Ordinal) + 3));
            return new AdditionOfFunctions(leftFunction, rightFunction);
        }
    }
}
