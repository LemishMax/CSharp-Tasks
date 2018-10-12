namespace Task_3.FunctionBuilders
{
    using Functions;

    internal class CosBuilder : FunctionBuilder
    {
        public override Function Build(string s) => new Cos();
    }
}
