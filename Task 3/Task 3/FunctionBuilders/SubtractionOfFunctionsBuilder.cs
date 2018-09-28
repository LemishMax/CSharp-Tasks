using System;
using Task_3.CommandBuilders;
using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class SubtractionOfFunctionsBuilder : FunctionBuilder
    {
        public override Function Build(string s)
        {
            var leftFunction =
                new AddInStorageBuilder().BuildFunction(s.Substring(0,
                    s.IndexOf(" - ", StringComparison.Ordinal)));
            var rightFunction =
                new AddInStorageBuilder().BuildFunction(
                    s.Substring(s.IndexOf(" - ", StringComparison.Ordinal) + 3));
            return new SubtractionOfFunctions(leftFunction, rightFunction);
        }
    }
}
