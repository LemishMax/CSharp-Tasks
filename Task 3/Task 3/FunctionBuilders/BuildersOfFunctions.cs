

namespace Task_3.FunctionBuilders
{
    using System.Collections.Generic;

    public class BuildersOfFunctions : BaseBuildersOfFunctions
    {
        private readonly Dictionary<string, FunctionBuilder> _functions = new Dictionary<string, FunctionBuilder>
        {
            { "^[U|u](naryMinus)?", new UnaryMinusOfFunctionBuilder()},
            { "^[F|f](unction)?[C|c](omposition)?", new FunctionCompositionBuilder() },
            { "^[A|a](dditionOf)?[F|f](unction)?", new AdditionOfFunctionsBuilder() },
            { "^[S|s](ubstringOf)?[F|f](unction)?", new SubtractionOfFunctionsBuilder() },
            { "^[F|f](unction)?", new ReferenceFunctionBuilder() },
            { "^[P|p](olynom(ial)?)?", new PolynomialBuilder() },
            { "^[L|l](inear)?", new LinearBuilder() },
            { "[S|s]in$", new SinBuilder() },
            { "[C|c]os$", new CosBuilder() }
        };

        public override Dictionary<string, FunctionBuilder> GetFunctions() => _functions;
        
    }
}
