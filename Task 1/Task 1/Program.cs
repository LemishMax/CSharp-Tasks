using System;

namespace Task_1
{
    public class Program
    {
        private static void Main()
        {
            Console.WriteLine("Данная программа выполняет уравнения вида ax^2+bx+c, где a не равно 0");
            Console.Write("Введите значение a:");
            double a;
            while (true)
            {
                a = CheckInput(Console.ReadLine());
                if (a != 0) {
                    break;
                }

                Console.WriteLine("Значение а не должно быть равным 0. Повторите ввод.");
            }

            Console.Write("Введите значение b:");
            var b = CheckInput(Console.ReadLine());
            Console.Write("Введите значение c:");
            var c = CheckInput(Console.ReadLine());
            var d = Math.Pow(b, 2) - 4 * a * c;
            if (d < 0)
            {
                Console.WriteLine("У этого уравнения корней нет.");
            }
            else
            {
                var x1 = (-b + Math.Sqrt(d)) / 2 / a;
                Console.WriteLine("Результат работы программы:\nx1=" + x1);
                if (d > 0)
                {
                    var x2 = (-b - Math.Sqrt(d)) / 2 / a;
                    Console.WriteLine("x2=" + x2);
                }

            }

            Console.ReadKey();
        }

        private static double CheckInput(string s)
        {
            double res;
            while (true)
            {
                if (double.TryParse(s, out res))
                {
                    break;
                }

                Console.WriteLine("Значение введено не верно. Повторите ввод.");
            }

            return res;
        }
    }
}
