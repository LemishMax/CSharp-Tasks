namespace Task_3.FunctionStorages
{
    using System;
    using Functions;

    internal class ReferenceResolver : IReferenceResolver
    {
        private readonly IFunctionStorage _functionStorage;

        public ReferenceResolver(IFunctionStorage functionStorage)
        {
            _functionStorage = functionStorage;
        }

        public Function Resolve(string name)
        {
            if (_functionStorage.IsStored(name))
            {
                return _functionStorage.GetFunction(name);
            }

            throw new Exception($"{name} не обнаружена");
        }
    }
}
