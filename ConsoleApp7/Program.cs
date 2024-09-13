using System;
using System.IO;
namespace CountWords
{ }

class Program
{
    static void Main()
    {
        string text = File.ReadAllText("C:\\Users\\Twe1ve\\Downloads\\Text.txt.txt");


        // Убираем знаки пунктуации
        var noPunctuationText = new string(text.Where(c => !char.IsPunctuation(c)).ToArray());

        // Приводим весь текст к нижнему регистру и разбиваем на слова
        var words = noPunctuationText.ToLower().Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        // Подсчитываем количество вхождений каждого слова
        var wordCount = words.GroupBy(word => word)
            .Select(group => new { Word = group.Key, Count = group.Count() })
            .OrderByDescending(x => x.Count)
            .Take(10);

        // Выводим результаты
        Console.WriteLine("10 самых частых слов:");
        foreach (var item in wordCount)
        {
            Console.WriteLine($"{item.Word}: {item.Count}");
        }
    }
}