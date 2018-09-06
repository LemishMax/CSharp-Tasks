using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task_2
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Данная программа считает количество уникальных слов в указаных Вами файлах. Поместите текстовые файлы в папку textfiles");
            Console.WriteLine("Введите названия файлов через пробел");
            var fileNames = Console.ReadLine()?.Split(' ');
            var uniqueWords = new HashSet<string>();
            foreach (var name in fileNames)
            {
                var path = Path.Combine("textfiles/", name);
                if (File.Exists(path))
                {
                    var words = File.ReadAllText(path)
                        .ToLower()
                        .Where(x => !char.IsPunctuation(x))
                        .Aggregate("", (s, c) => s + c)
                        .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); ;
                    foreach (var word in words)
                    {
                        uniqueWords.Add(word);
                    }
                }
                else
                {
                    Console.WriteLine($"Файл {name} не обнаружен.");
                }
            }

            Console.WriteLine("Количество уникальных слов в файлах: " + uniqueWords.Count);
            Console.ReadKey();
        }
    }
}
