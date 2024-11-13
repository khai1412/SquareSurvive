using System;
using System.Collections.Generic;

public static class Utility
{
    private static readonly Random random = new();
    
    public static T Random<T>(this IList<T> list)
    {
        if (list == null || list.Count == 0)
            throw new ArgumentException("The list cannot be null or empty.");
        
        int index = random.Next(list.Count);
        return list[index];
    }
}