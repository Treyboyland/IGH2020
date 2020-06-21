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
            
            pickup.transform.SetParent(currentPlayer.transform);
            pickup.OffsetLocally();
            currentPlayer.HasPickup = true;
            currentPlayer.CurrentPickup = pickup;
            currentPlayer.FirePickupEvent();

            StartCoroutine("Grow");
        }

        combination.OnCombinationComplete.RemoveListener(GivePlayerItem);
    }

    IEnumerator Grow() 
    {
        float startScale = currentPlayer.CurrentPickup.gameObject.transform.localScale.x;
        currentPlayer.CurrentPickup.gameObject.transform.localScale = new Vector3(0,0,0);
        currentPlayer.CurrentPickup.gameObject.SetActive(true);

        for (float ft = 0; ft <= startScale; ft += 0.05f) 
        {
            Vector3 scale = new Vector3(ft, ft, ft);
            currentPlayer.CurrentPickup.gameObject.transform.localScale = scale;
            yield return new WaitForSeconds(0.01f);
        }

        currentPlayer.CurrentPickup.gameObject.transform.localScale = new Vector3(startScale,startScale,startScale);

        if (currentPlayerControl != null)
        {
            currentPlayerControl.CanMove = true;
        }

        
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
