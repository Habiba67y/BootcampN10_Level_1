//Rosti shartiga uncha tushunmadim shunga tushunganimcha qildim🤷‍:
LinkedList<KeyValuePair<string, string>> SavolJavob = new LinkedList<KeyValuePair<string, string>>();
SavolJavob.AddLast(new KeyValuePair<string, string>(
    "Farishtalar ichidan qaysi biri Alloh taolo bilan anbiyo va rasullar orasida elchi bo'lgan?",
    "Jabroil alayhissalom"));
SavolJavob.AddLast( new KeyValuePair<string, string>(
    "Jon oluvchi farishta?",
    "Azroil alayhissalom"));
SavolJavob.AddLast(new KeyValuePair<string, string>(
    "Rizqlantiruvch farishta?",
    "Mikoil alayhissalom"));
SavolJavob.AddLast(new KeyValuePair<string, string>(
    "Qiyomat kuni sur chaluvchi farishta?",
    "Isrofil Alayhissalom"));
SavolJavob.AddLast(new KeyValuePair<string, string>(
    "Ikki yelkada turuvchi farishtalar qanday nomlanadi?",
    "Kiroman katibiyn"));
foreach (var sj in SavolJavob)
{
    Console.WriteLine(sj.Key);
    var answer = Console.ReadLine();
    if (sj.Value.Equals(answer, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine(true);
    }
    else
    {
        Console.WriteLine(false);
    }
}