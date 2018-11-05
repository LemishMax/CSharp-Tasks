namespace Task_3
{
    using System.Collections.Generic;
    using Functions;
    using Newtonsoft.Json;

    public class Serializer
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

        public Dictionary<string, Function> Deserialize(string s)
        {
            return s.Length == 0
                ? new Dictionary<string, Function>()
                : JsonConvert.DeserializeObject<Dictionary<string, Function>>(s, _settings);
        }

        public string Serialize(Dictionary<string, Function> functionStorage) => JsonConvert.SerializeObject(functionStorage, _settings);
    }
}
