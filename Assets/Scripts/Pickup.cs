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

    Queue<Sprite> spriteQueue = new Queue<Sprite>();

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
        PURPLE,
        ORANGE
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
        if (spriteQueue.Count == 0)
        {
            ShuffleSprites();
        }
        //currentSprite = possibleSprites[UnityEngine.Random.Range(0, possibleSprites.Count)];
        currentSprite = spriteQueue.Dequeue();
        Location = (DropOffLocation)Enum.Parse(typeof(DropOffLocation), locations[UnityEngine.Random.Range(0, locations.Length)]);
    }

    void ShuffleSprites()
    {
        if (spriteQueue.Count != 0)
        {
            spriteQueue.Clear();
        }
        List<Sprite> possible = new List<Sprite>(possibleSprites);
        possible.Shuffle();

        foreach (var spr in possible)
        {
            spriteQueue.Enqueue(spr);
        }
    }

    public static Color LocationToColor(DropOffLocation location)
    {
        switch (location)
        {
            case DropOffLocation.RED:
                return new Color(243.0f / 255, 28.0f / 255, 6.0f / 255);
            case DropOffLocation.ORANGE:
                return new Color(255.0f / 255, 147.0f / 255, 0.0f / 255);
            case DropOffLocation.BLUE:
                return new Color(52.0f / 255, 152.0f / 255, 219.0f / 255);
            case DropOffLocation.PURPLE:
                return new Color(142.0f / 255, 68.0f / 255, 173.0f / 255);
            default:
                return Color.white;
        }
    }

    public void OffsetLocally()
    {
        transform.localPosition = offset;
    }


}
