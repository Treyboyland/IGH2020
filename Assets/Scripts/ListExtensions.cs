using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static void Shuffle<T>(this List<T> list)
    {
        for (int i = 0; i < list.Count - 1; i++)
        {
            var chosenIndex = UnityEngine.Random.Range(i, list.Count);
            var chosen = list[chosenIndex];
            var current = list[i];
            list[i] = chosen;
            list[chosenIndex] = current;
        }
    }
}
