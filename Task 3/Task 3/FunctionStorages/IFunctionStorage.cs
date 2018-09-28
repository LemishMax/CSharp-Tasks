using System;
using Task_3.Functions;

namespace Task_3.FunctionStorages
{
    /// <summary>
    /// Используется для работы с хранилищами функций
    /// </summary>
    public interface IFunctionStorage
    {
        /// <summary>
        /// Добавляет функцию в хранилище
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <param name="func">Функция</param>
        /// <exception cref="Exception"></exception>
        void Add(string name, Function func);

        /// <summary>
        /// Удаляет функцию из хранилища
        /// </summary>
        /// <param name="name">Название удаляемой функции</param>
        /// <exception cref="Exception"></exception>
        void Delete(string name);

        /// <summary>
        /// Переименование функции
        /// </summary>
        /// <param name="name">Текущее название</param>
        /// <param name="newName">Новое название</param>
        /// <exception cref="Exception"></exception>
        void Rename(string name, string newName);

        /// <summary>
        /// Вычисляет значение функции в заданной точке
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <param name="point">Точка</param>
        /// <returns>Значение функции в заданной точке</returns>
        double ValueAtThePoint(string name, double point);

        /// <summary>
        /// Вычисляет производную функции
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <returns>Производную функции</returns>
        /// <exception cref="Exception"></exception>
        Function Derivative(string name);

        /// <summary>
        /// Проверяет хранится ли функция в хранилище
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <returns>Хранится ли функция в хранилище</returns>
        bool IsStored(string name);
    }
}
