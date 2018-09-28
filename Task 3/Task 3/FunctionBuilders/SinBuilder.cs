using Task_3.Functions;

namespace Task_3.FunctionBuilders
{
    internal class SinBuilder:FunctionBuilder
    {
        public override Function Build(string s) => new Sin();
    }
}
