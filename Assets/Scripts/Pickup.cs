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
    SpriteRenderer backgroundSprite;

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
                return Color.red;
            case DropOffLocation.BLACK:
                return Color.black;
            case DropOffLocation.BLUE:
                return new Color(0.0f, 47.0f / 255.0f, 255.0f, 1.0f);
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
