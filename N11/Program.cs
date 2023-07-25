using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Sources;

var d = new Document()
{
    Content = "Lorem ipsum dolor sit amet consectetur adipisicing elit. " +
    "quaerat est quas commodi quibusdam labore, nihil doloribus quam temporibus " +
    "inventore optio expedita consectetur voluptatem QUIDEM nulla soluta earum. " +
    "Numquam rem alias minima culpa iste distinctio. Eum similique est consequuntur minus, " +
    "odio nisi recusandae iure asperiores facere, reiciendis voluptate maiores! Repellat, dolorum!",
};
var da = new DocumentAnalyzer();
Console.WriteLine("Resultat: " + da.analiz(d));
public class DocumentAnalyzer
{
    public void analizUzunlik(Document document)
    {
        var words = document.Content.Split(' ', ',', '.', '?', '!');
        if (words.Length < 500)
        {
            Console.WriteLine($"- essayda so'zlar soni 500 dan kam bo'lgani uchun: -5 ball\n{words.Length}");
            document.score -= 5;
        }
    }
    public void analiz20FoizWord(Document document)
    {
        var sentences = document.Content.Split('.', '?', '!');
        var words = document.Content.Split(' ', ',', '.', '?', '!');
        var wordDistinct = words.Distinct().ToArray();
        foreach (var word in wordDistinct)
        {
            if (words.Count(c => c == word) <= words.Length / 100 * 20F)
            {
                Console.WriteLine($"- xohlagan 1 ta so'z takrorlanishi umumiy so'zlar sonini 20% dan ko'pini tashkil qilgani uchun - 5 ball\n{word}");
                document.score -= 5;
            }
        }
    }
    public void analizCapitalWord(Document document)
    {
        var sentences = document.Content.Split('.', '?', '!');
        for (int i = 0; i < sentences.Length - 1; i++)
        {
            var s = sentences[i].Trim();
            var w = s.Split(' ', ',', '.', '?', '!');
            var capitalizedString = string.Concat(w[0].Substring(0, 1).ToUpper(), w[0].Substring(1).ToLower());
            if (w[0] != capitalizedString)
            {
                Console.WriteLine($"- gapda 1-so'z capital bo'lmagani uchun - 5 ball\n{w[0]}");
                document.score -= 5;
            }
        }
    }
    public void analizMiddleOfTheSentence(Document document)
    {
        var sentences = document.Content.Split('.', '?', '!');
        for (int i = 0; i < sentences.Length - 1; i++)
        {
            var s = sentences[i].Trim();
            var w2 = s.Split(' ');
            for (int j = 1; j < w2.Length; j++)
            {
                if (w2[j].ToLower() != w2[j])
                {
                    Console.WriteLine($"- gapda birinchi so'z bo'lmagan so'zlar faqat kichik harflar bilan yozilmagan bo'lgani uchun - 10 ball\n{w2[j]}");
                    document.score -= 10;
                }
            }
        }
    }
    public void analizLengthOfWord(Document document)
    {
        var words = document.Content.Split(' ', ',', '.', '?', '!');
        foreach (var word in words)
        {
            if (word.Length == 20)
            {
                Console.WriteLine("- gapda so'zlar uzunligi 20 dan oshib ketgan bo'lsa - 20 ball\n{word.Length}");
                document.score -= 20;
            }
        }
    }
    public int analiz(Document document)
    {
        analizUzunlik(document);
        analiz20FoizWord(document);
        analizCapitalWord(document);
        analizMiddleOfTheSentence(document);
        analizLengthOfWord(document);
        return document.score;
    }
}
public class Document
{
    public string Content { get; set; }
    public int score = 100;
}