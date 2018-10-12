namespace Task_3.FunctionStorages
{
    using Functions;

    public interface IReferenceResolver
    {
        Function Resolve(string name);
    }
}
