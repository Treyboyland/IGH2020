using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool HasPickup = false;

    public Pickup CurrentPickup = null;

    public string GivenWord = "";

    int dropsCompleted = 0;

    public int DropsCompleted
    {
        get
        {
            return dropsCompleted;
        }
        set
        {
            if (dropsCompleted != value)
            {
                dropsCompleted = value;
                OnDropsUpdated.Invoke(dropsCompleted);
            }
        }
    }

    public IntEvent OnDropsUpdated = new IntEvent();
}
