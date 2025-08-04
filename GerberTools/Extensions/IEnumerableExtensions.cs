using System.Collections.Generic;
using System;
using System.Linq;

public static class IEnumerableExtensions
{
    public static IEnumerable<IEnumerable<T>> MakeGroupsOf<T>(this IEnumerable<T> source, int take)
    {
        var grouping = new List<T>();

        foreach (var item in source)
        {
            grouping.Add(item);
            if (grouping.Count == take)
            {
                yield return grouping;
                grouping = new List<T>();
            }
        }

        if (grouping.Any())
        {
            yield return grouping;
        }
    }
}