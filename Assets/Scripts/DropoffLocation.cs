using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class DropoffLocation : MonoBehaviour
{
    [SerializeField]
    Pickup.DropOffLocation Location = Pickup.DropOffLocation.RED;

    
    ButtonCombination combination = null;

    SpriteRenderer spriteRenderer = null;

    Player currentPlayer = null;
    PlayerControl currentPlayerControl = null;

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = Pickup.LocationToColor(Location);
        combination = GameObject.FindGameObjectWithTag("ButtonCombination").GetComponent<ButtonCombination>();
    }

    void ReleasePlayer()
    {
        currentPlayer.HasPickup = false;
        currentPlayer.CurrentPickup.gameObject.SetActive(false);
        currentPlayer.CurrentPickup = null;

        currentPlayerControl.CanMove = true;
        combination.OnCombinationComplete.RemoveListener(ReleasePlayer);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();

        if (player != null)
        {
            if (player.HasPickup && player.CurrentPickup.Location == Location)
            {
                currentPlayer = player;
                currentPlayerControl = other.gameObject.GetComponent<PlayerControl>();
                currentPlayerControl.CanMove = false;

                combination.CurrentPlayer = currentPlayer;
                combination.OnStartButtonCombinationDrop.Invoke(player.GivenWord);

                combination.OnCombinationComplete.AddListener(ReleasePlayer);
            }
        }
    }
}
