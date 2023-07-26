var users = new string[]
{
    "Peter Michael Brown",
    "John David Smith",
    "John Johns Jones",
    "G`ishtmat G`ishtmatov G`ishtmatovich"
};
Console.Write("=> ");
var n = Console.ReadLine();
foreach (var u in users)
{
    if (u.Contains(n, StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine(u);
    }
}