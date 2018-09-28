﻿using Task_3.FunctionStorages;

namespace Task_3.Commands
{
    /// <inheritdoc />
    /// <summary>
    /// Данный класс управляет методом вычисления значения функции в точке
    /// </summary>
    public class ValueFunction:ICommand
    {
        private readonly string _name;

        private readonly double _point;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ValueFunction"/>.
        /// </summary>
        /// <param name="name">Название функции</param>
        /// <param name="point">Значение x</param>
        public ValueFunction(string name, double point)
        {
            _name = name;
            _point = point;
        }

        /// <inheritdoc />
        /// <summary>
        /// Обращается к методу хранилища ValueAtPoint
        /// </summary>
        /// <param name="fs">Хранилище функций</param>
        /// <returns>Возвращает результат работы команды</returns>
        public string Execute(IFunctionStorage fs)
        {
            if (!fs.IsStored(_name))
            {
                return $"{_name} не найдена";
            }

            return $"Значение {_name} в точке {_point} = {fs.ValueAtThePoint(_name, _point)}";
        }
    }
}
