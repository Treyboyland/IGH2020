using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonoPool<T> : MonoBehaviour where T : MonoBehaviour
{
    Dictionary<T, List<T>> pools = new Dictionary<T, List<T>>();

    T InitializeObject(T obj)
    {
        if (!pools.ContainsKey(obj))
        {
            pools.Add(obj, new List<T>());
        }

        var newObj = Instantiate(obj);
        newObj.gameObject.SetActive(false);
        pools[obj].Add(newObj);

        return newObj;
    }

    public T GetObject(T obj)
    {
        if (!pools.ContainsKey(obj))
        {
            return InitializeObject(obj);
        }
        foreach (var pooledObj in pools[obj])
        {
            if (!pooledObj.gameObject.activeInHierarchy)
            {
                return pooledObj;
            }
        }
        return InitializeObject(obj);
    }

    public void DisableAll(T obj)
    {
        if (pools.ContainsKey(obj))
        {
            foreach (var pooledObj in pools[obj])
            {
                pooledObj.gameObject.SetActive(false);
            }
        }
    }
}
