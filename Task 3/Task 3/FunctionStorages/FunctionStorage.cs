using System;
using System.Collections.Generic;
using Task_3.Functions;

namespace Task_3.FunctionStorages
{
    /// <inheritdoc />
    /// <summary>
    /// Этот класс работает с хранилищем функций
    /// </summary>
    public class FunctionStorage : IFunctionStorage
    {
        private readonly Dictionary<string, Function> _functions = new Dictionary<string, Function>();

        /// <inheritdoc />
        /// <summary>
        /// Добавляет функцию в хранилище
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <param name="func">Функция</param>
        /// <exception cref="Exception"></exception>
        public void Add(string name, Function func)
        {
            if (IsStored(name))
            {
                throw new Exception($"Функция {name} уже добавлена в хранилище");
            }

            _functions.Add(name, func);
        }


        /// <inheritdoc />
        /// <summary>
        /// Удаляет функцию из хранилища
        /// </summary>
        /// <param name="name">Название удаляемой функции</param>
        /// <exception cref="Exception"></exception>
        public void Delete(string name)
        {
            if (!IsStored(name))
            {
                throw new Exception($"Функция {name} отсутствует в хранилище");
            }

            _functions.Remove(name);
        }


        /// <inheritdoc />
        /// <summary>
        /// Переименование функции
        /// </summary>
        /// <param name="name">Текущее название</param>
        /// <param name="newName">Новое название</param>
        /// <exception cref="Exception"></exception>
        public void Rename(string name, string newName)
        {
            if (!IsStored(name))
            {
                throw new Exception($"Функция {name} отсутствует в хранилище");
            }

            if (IsStored(newName))
            {
                throw new Exception($"Функция {newName} уже добавлена в хранилище");
            }

            _functions.Add(newName, _functions[name]);
            _functions.Remove(name);
        }


        /// <inheritdoc />
        /// <summary>
        /// Вычисляет значение функции в заданной точке
        /// </summary>
        /// <param name="name">Названние функции</param>
        /// <param name="point">Точка</param>
        /// <returns>Значение функции в заданной точке</returns>
        public double ValueAtThePoint(string name, double point)
        {
            return _functions[name].ValueAtPoint(point);
        }

        /// <inheritdoc />
        /// <summary>
        /// Вычисляет производную функции
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <returns>Производную функции</returns>
        /// <exception cref="T:System.Exception"></exception>
        public Function Derivative(string name)
        {
            if (!IsStored(name))
            {
                throw new Exception($"Функция {name} отсутствует в хранилище");
            }

            return _functions[name].Derivative();
        }
        
        /// <inheritdoc />
        /// <summary>
        /// Проверяет хранится ли функция в хранилище
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <returns>Хранится ли функция в хранилище</returns>
        public bool IsStored(string name)
        {
            return _functions.ContainsKey(name);
        }
    }
}
