namespace Task_3.FunctionBuilders
{
    using Functions;

    internal class SinBuilder : FunctionBuilder
    {
        public override Function Build(string s) => new Sin();
    }
}
