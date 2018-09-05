using System;
using System.Collections.Generic;
using System.IO;

namespace Task_2
{
    internal class Program
    {
        private static void Main()
        {
            Console.WriteLine("Данная программа считает количество уникальных слов в указаных Вами файлах");
            var fileNames = new List<string>();
            Console.WriteLine("Введите названия файлов через пробел");
            fileNames.AddRange(Console.ReadLine()?.Split(' '));
            var uniqueWords= new HashSet<string>();
            foreach (var name in fileNames)
            {
                var path = "../../../" + name;
                if (File.Exists(path))
                {
                    using (var sr = new StreamReader(path))
                    {
                        var content = sr.ReadToEnd();
                        var word = "";
                        foreach (var c in content)
                        {
                            if (char.IsLetterOrDigit(c))
                            {
                                word += c;
                            }else if (word.Length != 0 && (char.IsPunctuation(c) || char.IsWhiteSpace(c))){
                                uniqueWords.Add(word);
                                word = "";
                            } 
                        }

                        if (word.Length != 0)
                        {
                            uniqueWords.Add(word);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Файл "+name+" не обнаружен.");
                }
            }

            Console.WriteLine("Количество уникальных слов в файлах: " + uniqueWords.Count);
            Console.ReadKey();
        }
    }
}
