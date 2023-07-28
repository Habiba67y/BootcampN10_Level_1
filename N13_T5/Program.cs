using System.Text;
//japanese characterlar print bo'lmadi encoding decoding qilsam ham😓
string parol = "qwerty!2345";
var languages = new Dictionary<string, List<string>>();
languages["en"] = new List<string>()
{
    "Successfull Registration!",
    "Enter Your Password: ",
    "Account Blocked."
};
languages["uz"] = new List<string>()
{
    "Tizimga muvaffaqiyatli ro'yxatdan o'tdingiz!",
    "Parolingizni kiriting: ",
    "Akkount bloklangan."
};
languages["ja"] = new List<string>()
{
    "登録が成功しました！",
    "パスワードを入力してください: ",
    "アカウントがブロックされました."
};
languages["de"] = new List<string>()
{
    "Registrierung erfolgreich!",
    "Geben Sie Ihr Passwort ein: ",
    "Konto gesperrt."
};
Console.Write("Til tanlang:\n\tUzbek - uz\n\tEnglish - en\n\tJapan - ja\n\tGerman - de\n=> ");
var til = Console.ReadLine();
if (til != "uz" && til != "en" && til != "ja" && til != "de")
{
    Console.WriteLine("Xato buyruq!");
}
else
{
    Console.WriteLine(languages[til][1]);
    if (parol == Console.ReadLine())
    {
        Console.WriteLine(languages[til][0]);
    }
    else
    {
        Console.WriteLine(languages[til][2]);
    }
}

