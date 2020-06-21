using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent(typeof(SpriteRenderer))]
public class Pickup : MonoBehaviour
{
    [SerializeField]
    Vector3 offset = new Vector3();

    [SerializeField]
    SpriteRenderer backgroundSprite = null;

    [SerializeField]
    List<Sprite> possibleSprites = new List<Sprite>();

    Sprite currentSprite = null;

    public Sprite CurrentSprite
    {
        get
        {
            return currentSprite;
        }
    }

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

            if (backgroundSprite != null)
            {
                backgroundSprite.color = LocationToColor(location);
            }
            if (spriteRenderer != null)
            {
                spriteRenderer.sprite = currentSprite;
            }

        }
    }

    public void SetRandomLocation()
    {
        var locations = Enum.GetNames(typeof(DropOffLocation));
        currentSprite = possibleSprites[UnityEngine.Random.Range(0, possibleSprites.Count)];
        Location = (DropOffLocation)Enum.Parse(typeof(DropOffLocation), locations[UnityEngine.Random.Range(0, locations.Length)]);
    }

    public static Color LocationToColor(DropOffLocation location)
    {
        switch (location)
        {
            case DropOffLocation.RED:
                return new Color(243.0f/255, 28.0f/255, 6.0f/255);
            case DropOffLocation.BLACK:
                return new Color(230.0f/255, 126.0f/255, 34.0f/255);
            case DropOffLocation.BLUE:
                return new Color(52.0f/255, 152.0f/255, 219.0f/255);
            case DropOffLocation.GREEN:
                return new Color(142.0f/255, 68.0f/255, 173.0f/255);
            default:
                return Color.white;
        }
    }

    public void OffsetLocally()
    {
        transform.localPosition = offset;
    }


}
