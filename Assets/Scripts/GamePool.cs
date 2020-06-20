using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePool : MonoPool<MonoBehaviour>
{

    static GamePool _instance;

    public static GamePool Pool
    {
        get
        {
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }

        _instance = this;
        DontDestroyOnLoad(gameObject);
    }

}
