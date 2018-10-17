namespace Task_3.FunctionStorages
{
    using System;
    using System.Collections.Generic;
    using Functions;
    using Newtonsoft.Json;

    [Serializable]
    public class FunctionStorageDecorator : IFunctionStorage
    {
        [JsonProperty] private readonly IFunctionStorage _functionStorage;

        [JsonConstructor]
        public FunctionStorageDecorator(IFunctionStorage functionStorage)
        {
            _functionStorage = functionStorage;
        }

        public void Add(string name, Function func)
        {
            _functionStorage.Add(name, func);
            Logger.Log.Info($"Функция {name} {func} добавлена");
        }

        public void Delete(string name)
        {
            _functionStorage.Delete(name);
            Logger.Log.Info($"Функция {name} удалена");
        }

        public void Rename(string name, string newName)
        {
            _functionStorage.Rename(name, newName);
            Logger.Log.Info($"Функция {name} переименована. Новое название функции - {newName}");
        }

        public double ValueAtThePoint(string name, double point)
        {
            var result = _functionStorage.ValueAtThePoint(name, point);
            Logger.Log.Info($"Значение функции {name} в точке {point} = {result}");
            return result;
        }

        public Function Derivative(string name)
        {
            var result = _functionStorage.Derivative(name);
            Logger.Log.Info($"Производная функции {name} = {result}");
            return result;
        }

        public bool IsStored(string name)
        {
            return _functionStorage.IsStored(name);
        }

        public Function GetFunction(string name)
        {
            return _functionStorage.GetFunction(name);
        }

        public Dictionary<string, Function> GetStorage() => _functionStorage.GetStorage();
    }
}