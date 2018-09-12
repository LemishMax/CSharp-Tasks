using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_3
{
    internal class Program
    {
        private static readonly List<Polynomial> Polynomials = new List<Polynomial>();

        private static void Main()
        {
            Console.WriteLine("Данная программа выполняет вычисления над многочленами вида x^5+4x^3-2x+9.");
            var command = "";
            ShowCommands();
            while (command != "0")
            {
                Console.Write("\nВведите номер команды: ");
                command = Console.ReadLine();
                switch (command)
                {
                    case "1":
                        Console.Write("Введите максимальную степень многочлена: ");
                        int maxDegree;
                        while (true)
                        {
                            maxDegree = (int)CorrectInput();
                            if (maxDegree >= 1)
                            {
                                break;
                            }
                            Console.WriteLine("Степень должна быть >=1");
                        }


                        var coefficients = new double[maxDegree + 1];
                        for (var i = maxDegree; i >= 0; i--)
                        {
                            Console.Write($"Введите коеффициент x^{i}: ");
                            while (true)
                            {
                                coefficients[i] = CorrectInput();
                                if (i == maxDegree && coefficients[i] == 0)
                                {
                                    Console.Write("Коэффициент максимальной степени не должен равнятся нулю.\n Повторите ввод:");
                                }
                                else
                                {
                                    break;
                                }
                            }
                        }

                        var result = new Polynomial(coefficients);
                        Polynomials.Add(result);
                        Console.WriteLine($"Многочлен {result} добавлен");
                        break;
                    case "2":
                        Console.WriteLine("Сложение многочленов");
                        if (Polynomials.Count == 0)
                        {
                            Console.WriteLine("Список многочленов пуст. Добавьте многочлен");
                        }
                        else
                        {
                            var firstPolynomial = GetPolynomial();
                            var secondPolynomial = GetPolynomial();
                            result = firstPolynomial.Add(secondPolynomial);
                            Console.WriteLine($"\n{firstPolynomial} + {secondPolynomial} = {result}");
                            AddToList(result);
                        }

                        break;
                    case "3":
                        Console.WriteLine("Вычитание многочленов");
                        if (Polynomials.Count == 0)
                        {
                            Console.WriteLine("Список многочленов пуст. Добавьте многочлен");
                        }
                        else
                        {
                            var firstPolynomial = GetPolynomial();
                            var secondPolynomial = GetPolynomial();
                            result = firstPolynomial.Subtract(secondPolynomial);
                            Console.WriteLine($"\n{firstPolynomial} - {secondPolynomial} = {result}");
                            AddToList(result);
                        }

                        break;
                    case "4":
                        Console.WriteLine("Умножение многочлена на многочлен");
                        if (Polynomials.Count == 0)
                        {
                            Console.WriteLine("Список многочленов пуст. Добавьте многочлен");
                        }
                        else
                        {
                            var firstPolynomial = GetPolynomial();
                            var secondPolynomial = GetPolynomial();
                            result = firstPolynomial.MultiplyByThePolynomial(secondPolynomial);
                            Console.WriteLine($"\n{firstPolynomial} * {secondPolynomial} = {result}");
                            AddToList(result);
                        }

                        break;
                    case "5":
                        Console.WriteLine("Умножение многочлена на число");
                        if (Polynomials.Count == 0)
                        {
                            Console.WriteLine("Список многочленов пуст. Добавьте многочлен");
                        }
                        else
                        {
                            var firstPolynomial = GetPolynomial();
                            Console.Write("Введите множитель: ");
                            var multiplier = CorrectInput();
                            result = firstPolynomial.MultiplyByTheNumber(multiplier);
                            Console.WriteLine($"\n{firstPolynomial} * {multiplier} = {result}");
                            AddToList(result);
                        }

                        break;
                    case "6":
                        Console.WriteLine("Нахождение корня многочлена на заданом промежутке");
                        if (Polynomials.Count == 0)
                        {
                            Console.WriteLine("Список многочленов пуст. Добавьте многочлен");
                        }
                        else
                        {
                            var firstPolynomial = GetPolynomial();
                            Console.Write("Введите начальный интервал: ");
                            var startInterval = CorrectInput();
                            Console.Write("Введите конечный интервал: ");
                            var endInterval = CorrectInput();
                            Console.Write("Введите эпсилон: ");
                            var epsilon = CorrectInput();
                            var root = firstPolynomial.RootFinding(startInterval, endInterval, epsilon);
                            Console.WriteLine($"\nКорень на заданом участке: {root}");
                        }

                        break;
                    case "7":
                        Console.WriteLine("Список многочленов: ");
                        ShowPolynomials();
                        break;
                    case "8":
                        ShowCommands();
                        break;
                    default:
                        Console.WriteLine("Команда не обнаружена. Введите 8 чтобы вывести список команд");
                        break;
                }
            }
        }

        private static void AddToList(Polynomial polynomial)
        {
            Console.WriteLine($"Добавить {polynomial} в список? Y-Да N-Нет");
            while (true)
            {
                var answer = Console.ReadKey();
                if (answer.Key == ConsoleKey.Y)
                {
                    Polynomials.Add(polynomial);
                    Console.WriteLine("\nМногочлен добавлен");
                    return;
                }

                else if (answer.Key == ConsoleKey.N)
                {
                    Console.WriteLine("Многочлен не добавлен");
                    return;
                }

                Console.WriteLine("Некорректный ввод");
            }

        }

        private static double CorrectInput()
        {
            while (true)
            {
                if (double.TryParse(Console.ReadLine(), out var coefficient))
                {
                    return coefficient;
                }

                Console.WriteLine("Некорректный ввод.\n Повторите попытку:");
            }
        }

        private static Polynomial GetPolynomial()
        {
            Console.WriteLine("Выберите многочлен из списка:");
            ShowPolynomials();
            while (true)
            {
                var selectedPolynomial = CorrectInput();
                if (selectedPolynomial <= Polynomials.Count)
                {
                    return Polynomials.ElementAt((int)selectedPolynomial - 1);
                }

                Console.WriteLine("Некорректный ввод");
            }

        }

        private static void ShowPolynomials()
        {
            for (var i = 1; i <= Polynomials.Count; i++)
            {
                Console.WriteLine($"{i}. {Polynomials.ElementAt(i - 1)}");
            }
        }

        private static void ShowCommands()
        {
            Console.WriteLine("Список доступных команд:\n" +
                              "1.Добавить в список многочлен\n" +
                              "2.Сложение двух многочленов\n" +
                              "3.Вычитание двух многочленов\n" +
                              "4.Умножение многочлена на многочлен\n" +
                              "5.Умножение многочлена на число\n" +
                              "6.Нахождение корня многочлена на заданном промежутке\n" +
                              "7.Посмотреть список добавленных многочленов\n" +
                              "8.Посмотреть список команд\n" +
                              "0.Выход\n");
        }

    }
}
