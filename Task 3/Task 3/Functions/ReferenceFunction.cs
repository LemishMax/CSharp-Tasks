namespace Task_3.Functions
{
    using System;
    using FunctionStorages;
    using Newtonsoft.Json;

    public class ReferenceFunction : Function
    {
        [JsonProperty]
        private readonly string _name;

        public ReferenceFunction(string name)
        {
            name = name.Contains(" ") ? name.Substring(name.IndexOf(' ') + 1) : name;
            _name = name;
        }

        public override Function Derivative()
        {
            throw new NotImplementedException();
        }

        public override double ValueAtPoint(double point)
        {
            throw new NotImplementedException();
        }

        public string GetName() => _name;

        public override void ResolveReferences(IReferenceResolver referenceResolver)
        {
        }

        public override string ToString() => $"@{_name}";

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
