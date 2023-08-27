using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace N30_HT1
{
    public class DocumentAnalyzer
    {
        private int Score = 100;
        public async Task<int> AnalyzeAsync(string filePath)
        {
            //var fileStream = File.Open(filePath, FileMode.OpenOrCreate);
            var text = File.ReadAllText(filePath);
            await AnalyzeLengthAsync(text);
            await DublicateWordsAsync(text);
            await CapitalWordAsync(text);
            await LowerCaseWordsAsync(text);
            await LengthOfWordAsync(text);
            return Score;

        }
        public async Task AnalyzeLengthAsync(string text)
        {
            var words = text.Split(' ', ',', '.', '?', '!');
            if (words.Length < 500)
            {
                Console.WriteLine($"- essayda so'zlar soni 500 dan kam bo'lgani uchun: -5 ball\nLength: {words.Length}");
                Score -= 5;
            }
        }
        public async Task DublicateWordsAsync(string text)
        {
            var sentences = text.Split('.', '?', '!');
            var words = text.Split(' ', ',', '.', '?', '!');
            var wordDistinct = words.Distinct().ToArray();
            foreach (var word in wordDistinct)
            {
                if (words.Count(c => c == word) <= words.Length / 100 * 20F)
                {
                    Console.WriteLine($"- xohlagan 1 ta so'z takrorlanishi umumiy so'zlar sonini 20% dan ko'pini tashkil qilgani uchun - 5 ball\n{word}");
                    Score -= 5;
                }
            };
        }
        public async Task CapitalWordAsync(string text)
        {
            var sentences = text.Split('.', '?', '!');
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                var s = sentences[i].Trim();
                var w = s.Split(' ', ',', '.', '?', '!');
                var capitalizedString = string.Concat(w[0].Substring(0, 1).ToUpper(), w[0].Substring(1).ToLower());
                if (w[0] != capitalizedString)
                {
                    Console.WriteLine($"- gapda 1-so'z capital bo'lmagani uchun - 5 ball\n{w[0]}");
                    Score -= 5;
                }
            }
        }
        public async Task LowerCaseWordsAsync(string text)
        {
            var sentences = text.Split('.', '?', '!');
            for (int i = 0; i < sentences.Length - 1; i++)
            {
                var s = sentences[i].Trim();
                var w2 = s.Split(' ');
                for (int j = 1; j < w2.Length; j++)
                {
                    if (w2[j].ToLower() != w2[j])
                    {
                        Console.WriteLine($"- gapda birinchi so'z bo'lmagan so'zlar faqat kichik harflar bilan yozilmagan bo'lgani uchun - 10 ball\n{w2[j]}");
                        Score -= 10;
                    }
                }
            }
        }
        public async Task LengthOfWordAsync(string text)
        {
            var words = text.Split(' ', ',', '.', '?', '!');
            foreach (var word in words)
            {
                if (word.Length == 20)
                {
                    Console.WriteLine("- gapda so'zlar uzunligi 20 dan oshib ketgan bo'lsa - 20 ball\n{word.Length}");
                    Score -= 20;
                }
            }
        }
    }
}
