using System.Threading.Channels;

var aggregator = null as ICollectionAggregator;
aggregator = new CollectionAggregator();
var listA = new List<int>() { 1, 2, 3 };
var listB = new List<int>() { 2, 4, 5 };
Console.WriteLine("Concat result : ");
aggregator.Concat(listA, listB).ForEach(Console.WriteLine);

Console.WriteLine();
Console.WriteLine("Intersect result : ");
aggregator.Intersect(listA, listB).ForEach(Console.WriteLine);

Console.WriteLine();
Console.WriteLine("Except result: ");
aggregator.Except(listA, listB).ForEach(Console.WriteLine);

Console.WriteLine();
Console.WriteLine("Union result: ");
aggregator.Union(listA, listB).ForEach(Console.WriteLine);

public interface ICollectionAggregator
{
    List<T> Concat<T>(in List<T> listA, in List<T> listB);

    List<T> Intersect<T>(in List<T> listA, in List<T> listB);

    List<T> Except<T>(in List<T> listA, in List<T> listB);

    List<T> Union<T>(in List<T> listA, in List<T> listB);
}

public class CollectionAggregator : ICollectionAggregator
{
    public List<T> Concat<T>(in List<T> listA, in List<T> listB)
    {
        var list = new List<T>();
        list.AddRange(listA);
        list.AddRange(listB);

        return list;
    }

    public List<T> Intersect<T>(in List<T> listA, in List<T> listB)
    {
        var list = new List<T>();
        foreach (var itemA in listA)
            if (listB.Contains(itemA))
                list.Add(itemA);

        return list;
    }

    public List<T> Except<T>(in List<T> listA, in List<T> listB)
    {
        var list = new List<T>();
        foreach (var itemA in listA)
            if (!listB.Contains(itemA))
                list.Add(itemA);

        return list;
    }

    public List<T> Union<T>(in List<T> listA, in List<T> listB)
    {
        var list = new List<T>();
        var dict = new Dictionary<T, int>();
        foreach (var item1 in Concat(listA, listB))
        {
            var count = 0;
            foreach (var item2 in Concat(listA, listB))
            {
                if (EqualityComparer<T>.Default.Equals(item1, item2))
                {
                    count++;
                }
            }
            if (!dict.ContainsKey(item1))
            {
                dict.Add(item1, count);
            }
        }
        foreach (var i in dict)
        {
            list.Add(i.Key);
        }
        return list;
    }
}

