//using static System.Net.Mime.MediaTypeNames;

//string essay = "C# (pronounced \"See Sharp\") is a modern, object-oriented, and type-safe programming language." +
//" C# enables developers to build many types of secure and robust applications that run in dotnet. C# has its roots in the " +
//"C family of languages and will be immediately familiar to C, C++, Java, and JavaScript programmers. this tour provides an overview " +
//"of the major components of the language in C# 11 and earlier. If you want to explore the language through interactive examples, " +
//"try the introduction to C# tutorials.";
//var sentences = essay.Split('.', '?', '!');
//var words = essay.Split(' ');
//int ball = 100;
//if (words.Length < 500)
//{
//    Console.WriteLine($"- essayda so'zlar soni 500 dan kam bo'lgani uchun: -5 ball\n{words.Length}");
//    ball -= 5;
//}

//foreach (var word in words)
//    if (words.Count(c => c == word) <= words.Length / 100 * 20F)
//    {
//        Console.WriteLine($"- xohlagan 1 ta so'z takrorlanishi umumiy so'zlar sonini 20% dan ko'pini tashkil qilgani uchun - 5 ball\n{word}");
//        ball -= 5;
//    }

//foreach (var word in words)
//    if (words.Length < 20)
//    {
//        Console.WriteLine($"- gapda so'zlar uzunligi 20 dan oshib ketgan bo'lsa - 20 ball\n{word.Length}");
//        ball -= 20;
//    }

//for (int i = 0; i < sentences.Length - 1; i++)
//{
//    var s = sentences[i].Trim();
//    if (Char.IsLower(s[0]))
//    {
//        var w = s.Split(' ');
//        Console.WriteLine($"- gapda 1-so'z capital bo'lmagani uchun - 5 ball\n{w[0]}");
//        ball -= 5;
//    }
//    var w2 = s.Split(' ');
//    for (int j = 1; j < w2.Length; j++)
//    {
//        if (w2[j].ToUpper() == w2[j])
//        {
//            Console.WriteLine($"- gapda birinchi so'z bo'lmagan so'zlar faqat kichik harflar bilan yozilmagan bo'lsa - 10 ball\n{w2[j]}");
//            ball -= 10;
//        }
//    }
//}
//Console.WriteLine($"Resultat: {ball} ball");