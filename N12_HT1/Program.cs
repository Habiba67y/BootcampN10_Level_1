var u1 = new User()
{
    ism = "Habiba",
    familiya = "Sattorova",
    sharif = "Shuhrat qizi"
};
var u2 = new User()
{
    ism = "Habiba",
    familiya = "Sattorova",
    sharif = "Shuhrat qizi"
};
Console.WriteLine(u1.fullName);
Console.WriteLine(u2.fullName);
Console.WriteLine(u1.Equals(u2));
public class User
{
    public string ism;
    public string familiya;
    public string sharif;
    public string fullName
    {
        get { return $"{ism} {familiya} {sharif}";  }
        set { value = $"{ism} {familiya} {sharif}";
    }
    public override bool Equals(object? obj)
    {
        return this.GetHashCode() == obj.GetHashCode();
    }
    public override int GetHashCode()
    {
        return ism.GetHashCode()+familiya.GetHashCode()+sharif.GetHashCode()+fullName.GetHashCode();
    }
}