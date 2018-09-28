using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class CosBuilder : FunctionBuilder
    {
        public override Function Build(string s) => new Cos();
    }
}
