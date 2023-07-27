var standartSavol = new List<string>();
standartSavol.Add("What is the capital city of Australia?");
standartSavol.Add("Which river is the longest in South America?");
standartSavol.Add("Which continent is known as the \"Land Down Under\"?");
standartSavol.Add("In which continent is the Sahara Desert located?");
standartSavol.Add("What is the highest mountain in the European Alps?");
var standartJavob = new List<string>();
standartJavob.Add("Canberra");
standartJavob.Add("Amazon");
standartJavob.Add("Australia");
standartJavob.Add("Africa");
standartJavob.Add("Mont Blanc");
var osonSavol = new List<string>();
osonSavol.Add("Name the largest island in the world");
osonSavol.Add("What is the largest lake by surface area in Africa?");
osonSavol.Add("Name the smallest country in the world by land area.");
var osonJavob = new List<string>();
osonJavob.Add("Greenland");
osonJavob.Add("Victoria");
osonJavob.Add("Vativan");
var qiyinSavol = new List<string>();
qiyinSavol.Add("Which country is home to the world's largest coral reef system?");
qiyinSavol.Add("What is the deepest oceanic trench in the world?");
qiyinSavol.Add("Name the active volcano in Italy that famously erupted in AD 79, burying the city of Pompeii.");
var qiyinJavob = new List<string>();
qiyinJavob.Add("Australia");
qiyinJavob.Add("Mariana");
qiyinJavob.Add("Mount Vesuvius");
int countTrue = 0;
int countFalse = 0;
int index1 = 0;
int index2 = 0;
for (int i = 0; i < standartSavol.Count(); i++)
{
    Console.WriteLine(standartSavol[i]);
    var answer = Console.ReadLine();
    if (standartJavob[i].Equals(answer, StringComparison.OrdinalIgnoreCase))
    {
        countTrue++;
        Console.WriteLine(true);
    }
    else 
    {
        countFalse++;
        Console.WriteLine(false);
    }
    if (countTrue == 2)
    {
        standartSavol.Insert(i+1, qiyinSavol[index1]);
        standartJavob.Insert(i+1, qiyinJavob[index1]);
        index1++;
  //      i--;
        countTrue = 0;
    }
    if (countFalse == 2)
    {
        standartSavol.Insert(i+1, osonSavol[index2]);
        standartJavob.Insert(i+1, osonJavob[index2]);
        index2++;
   //     i--;
        countFalse = 0;
    }
}