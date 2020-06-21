using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUi : MonoBehaviour
{
    [SerializeField]
    Image background;

    [SerializeField]
    Image foreground;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        player.OnNewPickup.AddListener(SetPickup);
        player.OnDropoffComplete.AddListener(SetTransparent);
        SetTransparent();
    }

    void SetTransparent()
    {
        var backColor = background.color;
        backColor.a = 0;
        var foreColor = foreground.color;
        foreColor.a = 0;

        background.color = backColor;
        foreground.color = foreColor;
    }

    void SetPickup(Pickup pickup)
    {
        background.color = Pickup.LocationToColor(pickup.Location);
        foreground.sprite = pickup.CurrentSprite;
        var foreColor = foreground.color;
        foreColor.a = 1.0f;
        foreground.color = foreColor;
    }

}
