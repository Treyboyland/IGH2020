using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropoffLocation : MonoBehaviour
{
    [SerializeField]
    Pickup.DropOffLocation Location;

    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Pickup.LocationToColor(Location);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.HasPickup && player.CurrentPickup.Location == Location)
            {
                player.HasPickup = false;
                player.CurrentPickup.gameObject.SetActive(false);
                player.CurrentPickup = null;
            }
        }
    }
}
