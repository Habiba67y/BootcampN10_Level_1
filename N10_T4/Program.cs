//bu misolli shartiga tushunmadim, tushunganimcha qildim
var bm = new BlogManagaer();
bm.blogPosts.Add(new BlogPost()
{
    Id = 1,
    Title = ".Net",
    Content = new List<string> {
        "NET Framework — 2002-yilda Microsoft tomonidan chiqarilgan dasturiy platformadir.",
        "Platforma turli dasturlash tillari: C#, Visual Basic .NET, J# va boshqalar uchun mos Common Language Runtime (CLR)ga asoslangan.",
        "CLR funksiyasi ushbu platformadan foydalanadigan har qanday dasturlash tilida mavjud."
    },
    Tag = "c#, .Net",
    Likes = 25,
    Dislikes = 1
});
bm.blogPosts.Add(new BlogPost()
{
    Id = 2,
    Title = "Makka",
    Content = new List<string>
    {
        "Makka (arabcha: Makkah Al-Mukarramah) — musulmonlar uchun muqaddas hisoblanadigan shahar.",
        "Saudiya Arabistonining gʻarbida, Qizil dengizdan 70 km uzoqlikda joylashgan. Hijoz viloyatining maʼmuriy markazi.",
        "Aholisi 2 mln. kishidan ortiq (2020). Aholi soni boʻyicha Ar-Riyod va Jiddadan keyin uchinchi oʻrinda turadi."
    },
    Tag = "Makka, Ka'ba, Haj, Umra",
    Likes = 45,
    Dislikes = 0
});
bm.blogPosts.Add(new BlogPost()
{
    Id = 3,
    Title = "Madina",
    Content = new List<string>
    {
        "Madina (arab, nomi — Madinat Rasulilloh yoki Madinat un-Nabi — paygʻambar shahri) — Saudiya Arabistonidagi shahar, mamlakatning gʻarbiy qismida, Hijoz viloyatida, Qizil dengizdan 250 km sharqdagi vohada joylashgan. Aholisi 750 ming kishiga yaqin (2002).",
        "Shaharga asos solingan vaqt maʼlum emas. Shahar Madinai-Munavvara — Nurafshon shahar, al-Islom, Qalb al-Islom, Dor al-Islom, Dor as-Sunna kabi 95 dan ortiq nom bilan ulugʻlanadi."
    },
    Tag = "madinatu rasulillah, madinatun-nabiy",
    Likes = 40,
    Dislikes = 0
});
bm.Analyze(bm.blogPosts);
foreach (var bp in bm.blogPosts)
{
    Console.WriteLine($"Title: {bp.Title}\nLikes: {bp.Likes}");
}
public class BlogPost
{
    public int Id { get; set; }
    public string Title { get; set; }
    public List<string> Content = new List<string>();
    public string Tag { get; set; }
    public int Likes { get; set; }
    public int Dislikes { get; set; }
}

public class BlogManagaer
{
    public List<BlogPost> blogPosts = new List<BlogPost>();
    public void Analyze(List<BlogPost> blogPosts)
    {
        foreach (var bp1 in blogPosts)
        {
            var count = 0;
            foreach (var bp2 in blogPosts)
            {
                if (bp1.Tag == bp2.Tag)
                {
                    count++;
                }
            }
            if (count == 1)
            {
                Console.WriteLine($"Unique topic is: {bp1.Tag}");
            }
        }
        var averageContentLength = 0;
        for (int i = 0; i < blogPosts.Count - 1; i++)
        {
            for (int j = i + 1; j < blogPosts.Count; j++)
            {
                if (blogPosts[i].Likes > blogPosts[j].Likes)
                {
                    var temp = blogPosts[i];
                    blogPosts[i]= blogPosts[j];
                    blogPosts[j]= temp;
                }
            }
            averageContentLength += blogPosts[i].Content.Count;
        }
        averageContentLength/=blogPosts.Count;
        Console.WriteLine($"O'rtacha kontent uzunligi: {averageContentLength}");
    }
}