namespace Task_3
{
    using FunctionStorages;
    using Newtonsoft.Json;

    internal class Serializer
    {
        private readonly JsonSerializerSettings _settings =
            new JsonSerializerSettings
            {
                ConstructorHandling = ConstructorHandling.Default,
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented,
                ObjectCreationHandling = ObjectCreationHandling.Auto,
                PreserveReferencesHandling = PreserveReferencesHandling.Objects
            };

        public IFunctionStorage Deserialize(string s)
        {
            return s.Length == 0
                ? new FunctionStorage()
                : JsonConvert.DeserializeObject<FunctionStorage>(s, _settings);
        }

        public string Serialize(IFunctionStorage functionStorage) => JsonConvert.SerializeObject(functionStorage, _settings);
    }
}
