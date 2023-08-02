using System.Collections;
using System.ComponentModel.Design;
var a = Console.ReadLine();
var m = new misol();
Console.WriteLine(m.hisoblash(a));
//while (true)
//{
//    if (a.Contains("(") && a.Contains(")"))
//    {
//        int index1 = 0;
//        int index2 = 0;
//        var b = "";
//        var c = "";
//        for (int i = 0; i < a.Length; i++)
//        {
//            if (a[i] == '(')
//            {
//                index1 = i + 1;
//            }
//            if (a[i] == ')')
//            {
//                index2 = i - 1;
//            }
//        }
//        for (int i = 0; i < a.Length; i++)
//        {
//            if (i < index1 - 1)
//            {
//                b += a[i];
//            }
//            else
//            {
//                c += a[i];
//            }
//        }
//        if (m.hisoblash(c) >= 0)
//        {
//            b += Convert.ToString(m.hisoblash(c));
//        }
//        else
//        {
//            if (b[b.Length - 1] == '+')
//            {
//                b.Remove(b[b.Length - 1]);
//                b += '-';
//                b += Convert.ToString((-1) * m.hisoblash(c));
//            }
//            if (b[b.Length - 1] == '-')
//            {
//                b.Remove(b[b.Length - 1]);
//                b += '+';
//                b += Convert.ToString((-1) * m.hisoblash(c));
//            }
//            if (b[b.Length - 1] == '*')
//            {
//                b += Convert.ToString((-1) * m.hisoblash(c));
//                b = "-" + b;
//            }
//        }
//    }
//}
public class misol
{
    public float hisoblash(string a)
    {
        var b = "";
        var c = new ArrayList();
        var d = new ArrayList();
        if (a[0] == '-')
        {
            b = "-";
        }
        foreach(var i in a)
        {
            if (Char.IsDigit(i) || i == '.')
            {
                b += i;
            }
            else
            {
                if (a[0] != '-')
                {
                    c.Add(float.Parse(b));
                    c.Add(i);
                    b = "";
                }
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

