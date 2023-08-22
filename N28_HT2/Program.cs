using N28_HT2.DataAccess;
using N28_HT2.Models;

var cloneableList = new CloneableList<StorageFile>();
cloneableList.Add(new StorageFile("bir file nomi", "kerakli narsalar saqlangan", 50));
cloneableList.Add(new StorageFile("qandaydir file nomi", "keraksiz narsalar saqlangan", 45));
cloneableList.Add(new StorageFile("yana bir file nomi", "bir narsalar", 55));
cloneableList.Add(new StorageFile("bunisiga topomadim", "yana bir narsalar", 40));
var cloneableList2 = (List<StorageFile>)cloneableList.Clone();
var compare = true;
for (var i = 0; i < cloneableList.Count(); i++)
{
    if (cloneableList[i] != cloneableList2[i])
    {
        compare = false;
    }
}
Console.WriteLine("original list ni o'zgartirishdan oldin: "+compare);
cloneableList.Add(new StorageFile("file", "description", 60));
cloneableList.Remove(cloneableList[0]);

compare = true;
for (var i = 0; i < cloneableList.Count(); i++)
{
    if (cloneableList[i] != cloneableList2[i])
    {
        compare = false;
    }
}
Console.WriteLine("Keyin: "+compare);

