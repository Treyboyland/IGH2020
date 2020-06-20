using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLocation : MonoBehaviour
{
    [SerializeField]
    ButtonCombination combination = null;

    [SerializeField]
    Pickup pickupPrefab = null;

    Player currentPlayer = null;
    PlayerControl currentPlayerControl = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void GivePlayerItem()
    {
        if (currentPlayer != null)
        {
            var pickup = (Pickup)GamePool.Pool.GetObject(pickupPrefab);
            pickup.SetRandomLocation();
            pickup.gameObject.SetActive(true);
            pickup.transform.SetParent(currentPlayer.transform);
            pickup.OffsetLocally();
            currentPlayer.HasPickup = true;
            currentPlayer.CurrentPickup = pickup;
        }
        if (currentPlayerControl != null)
        {
            currentPlayerControl.CanMove = true;
        }

        combination.OnCombinationComplete.RemoveListener(GivePlayerItem);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        var player = other.gameObject.GetComponent<Player>();
        var playerControl = other.gameObject.GetComponent<PlayerControl>();
        if (player != null && playerControl != null)
        {
            if (player.HasPickup)
            {
                return;
            }
            if (currentPlayer == null)
            {
                currentPlayer = player;
            }
            if (currentPlayerControl == null)
            {
                currentPlayerControl = playerControl;
            }
            playerControl.CanMove = false;
            combination.CurrentPlayer = player;
            combination.OnStartButtonCombination.Invoke();
            

            combination.OnCombinationComplete.AddListener(GivePlayerItem);
        }
    }
}
