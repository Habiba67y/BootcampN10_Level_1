var str1 = new string[]
{
    "John",
    "Tim",
    "Tom"
};
var str2 = new string[]
{
    "John",
    "Tom",
    "Tim"
};
string str;
for (int i = 0; i < str1.Length - 1; i++)
{
    for (int j = i + 1; j < str1.Length; j++)
    {
        if (string.Compare(str1[i], str1[j]) > 0)
        {
            str = str1[i];
            str1[i] = str1[j];
            str1[j] = str;
        }
    }
}
for (int i = 0; i < str2.Length - 1; i++)
{
    for (int j = i + 1; j < str2.Length; j++)
    {
        if (string.Compare(str2[i], str2[j]) > 0)
        {
            str = str2[i];
            str2[i] = str2[j];
            str2[j] = str;
        }
    }
}
var tenglik = true;
for (int i = 0; i < 3; i++)
{
    if (str1[i] != str2[i])
    {
        tenglik = false;
    }
}
Console.WriteLine(tenglik);