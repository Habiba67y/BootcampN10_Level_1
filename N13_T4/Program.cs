var standartSavol = new Dictionary<string, string>();
standartSavol.Add("What is the capital city of Australia?", "Canberra");
standartSavol.Add("Which river is the longest in South America?", "Amazon");
standartSavol.Add("Which continent is known as the \"Land Down Under\"?", "Australia");
standartSavol.Add("In which continent is the Sahara Desert located?", "Africa");
standartSavol.Add("What is the highest mountain in the European Alps?" , "Mont Blanc");
var osonSavol = new Dictionary<string, string>();
osonSavol.Add("Name the largest island in the world","Greenland");
osonSavol.Add("What is the largest lake by surface area in Africa?" ,"Victoria");
osonSavol.Add("Name the smallest country in the world by land area.","Vatican");
var qiyinSavol = new Dictionary<string, string>();
qiyinSavol.Add("Which country is home to the world's largest coral reef system?","Australia");
qiyinSavol.Add("What is the deepest oceanic trench in the world?","Mariana");
qiyinSavol.Add("Name the active volcano in Italy that famously erupted in AD 79, burying the city of Pompeii." , "Mount Vesuvius");
int countTrue = 0;
int countFalse = 0;
int index1 = 0;
int index2 = 0;
for (int i = 0; i < standartSavol.Count(); i++)
{
    Console.WriteLine(standartSavol.ElementAt(i).Key);
    var answer = Console.ReadLine();
    if (standartSavol.ElementAt(i).Value.Equals(answer, StringComparison.OrdinalIgnoreCase))
    {
        countTrue++;
    }
    else 
    {
        countFalse++;
    }
    if (countTrue == 2)
    {
        Console.WriteLine(qiyinSavol.ElementAt(index1).Key);
        index1++;
        countTrue = 0;
    }
    if (countFalse == 2)
    {
        Console.WriteLine(osonSavol.ElementAt(index2).Key);
        index2++;
        countFalse = 0;
    }
}