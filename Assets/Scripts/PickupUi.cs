using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupUi : MonoBehaviour
{
    [SerializeField]
    Image background = null;

    [SerializeField]
    Image foreground = null;

    [SerializeField]
    Player player = null;

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
        foreColor.a = 100;

        background.color = backColor;
        foreground.color = foreColor;
    }

    IEnumerator Shrink() 
    {
        for (float ft = 1f; ft >= 0; ft -= 0.1f) 
        {
            yield return null;
        }
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
