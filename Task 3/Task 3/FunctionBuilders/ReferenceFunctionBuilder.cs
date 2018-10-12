namespace Task_3.FunctionBuilders
{
    using Functions;

    internal class ReferenceFunctionBuilder : FunctionBuilder
    {
        public override Function Build(string s) => new ReferenceFunction(s);
    }
}
