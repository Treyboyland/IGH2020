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
    bool shrinking = false;

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
        StartCoroutine("Shrink");
    }

    IEnumerator Shrink() 
    {
        float startScale = currentPlayer.CurrentPickup.gameObject.transform.localScale.x;
        for (float ft = startScale; ft > 0; ft -= 0.05f) 
        {
            Vector3 scale = new Vector3(ft, ft, ft);
            currentPlayer.CurrentPickup.gameObject.transform.localScale = scale;
            yield return new WaitForSeconds(0.01f);
        }

        currentPlayer.CurrentPickup.gameObject.SetActive(false);
        currentPlayer.CurrentPickup.gameObject.transform.localScale = new Vector3(startScale, startScale, startScale);
        currentPlayer.CurrentPickup = null;

        currentPlayerControl.CanMove = true;
        currentPlayer.DropsCompleted++;
        currentPlayer.OnDropoffComplete.Invoke();
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
