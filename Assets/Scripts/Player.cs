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
                if (dropsCompleted < value)
                {
                    TotalDropsCompleted += value - dropsCompleted;
                }
                dropsCompleted = value;
                OnDropsUpdated.Invoke(dropsCompleted);
            }
        }
    }

    int totalDropsCompleted = 0;

    public int TotalDropsCompleted
    {
        get
        {
            return totalDropsCompleted;
        }
        set
        {
            if (totalDropsCompleted != value)
            {
                totalDropsCompleted = value;
            }
        }
    }

    public IntEvent OnDropsUpdated = new IntEvent();

    public IntEvent OnTotalDropsUpdated = new IntEvent();

    public PickupEvent OnNewPickup = new PickupEvent();

    public EmptyEvent OnDropoffComplete = new EmptyEvent();

    public void FirePickupEvent()
    {
        OnNewPickup.Invoke(CurrentPickup);
    }
}
