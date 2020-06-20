using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3();


    SpriteRenderer spriteRenderer;


    public enum DropOffLocation
    {
        RED,
        BLUE,
        GREEN,
        BLACK
    }

    DropOffLocation location = DropOffLocation.RED;

    public DropOffLocation Location
    {
        get
        {
            return location;
        }
        set
        {
            location = value;
            spriteRenderer = spriteRenderer == null ? GetComponent<SpriteRenderer>() : spriteRenderer;

            if (spriteRenderer != null)
            {
                spriteRenderer.color = LocationToColor(location);
            }
        }
    }

    public void SetRandomLocation()
    {
        var locations = Enum.GetNames(typeof(DropOffLocation));
        Location = (DropOffLocation)Enum.Parse(typeof(DropOffLocation), locations[UnityEngine.Random.Range(0, locations.Length)]);
    }

    public static Color LocationToColor(DropOffLocation location)
    {
        switch (location)
        {
            case DropOffLocation.RED:
                return Color.red;
            case DropOffLocation.BLACK:
                return Color.black;
            case DropOffLocation.BLUE:
                return Color.blue;
            case DropOffLocation.GREEN:
                return Color.green;
            default:
                return Color.white;
        }
    }

    public void OffsetLocally()
    {
        transform.localPosition = offset;
    }


}
