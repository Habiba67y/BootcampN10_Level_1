using System.Collections;
using System.ComponentModel.Design;
var a = Console.ReadLine();
var b = a.Split('(',')');
foreach (var c in b)
{
    Console.WriteLine(c);
}

public class misol
{
    public float hisoblash(string a)
    {
        var b = "";
        var c = new ArrayList();
        var d = new ArrayList();
        foreach (var i in a)
        {
            if (Char.IsDigit(i) || i == '.')
            {
                b += i;
            }
            else
            {
                c.Add(float.Parse(b));
                c.Add(i);
                b = "";
            }
        }
        c.Add(float.Parse(b));
        float e;
        while (true)
        {
            if (c.Contains('*') || c.Contains('/'))
            {
                for (int i = 0; i < c.Count - 1; i++)
                {
                    if (Convert.ToString(c[i + 1]) == "*")
                    {
                        e = (float)c[i] * (float)c[i + 2];
                        d.Add(e);
                        var j = i + 3;
                        if (c.Count > j)
                        {
                            for (int k = j; k < c.Count; k++)
                            {
                                d.Add(c[i]);
                            }
                        }
                        c = new ArrayList(d);
                        d.Clear();
                        break;
                    }
                    else if (Convert.ToString(c[i + 1]) == "/")
                    {
                        e = (float)c[i] / (float)c[i + 2];
                        d.Add(e);
                        var j = i + 3;
                        if (c.Count > j)
                        {
                            for (int k = j; k < c.Count; k++)
                            {
                                d.Add(c[i]);
                            }
                        }
                        c = new ArrayList(d);
                        d.Clear();
                        break;
                    }
                    else
                    {
                        d.Add(c[i]);
                    }
                }
            }
            else
            {
                break;
            }
        }
        var sum = (float)c[0];
        for (int i = 0; i < c.Count; i++)
        {
            if (Convert.ToString(c[i]) == "+")
            {
                sum += (float)c[i + 1];
            }
            if (Convert.ToString(c[i]) == "-")
            {
                sum -= (float)c[i + 1];
            }
        }
        return sum;
    }
}

