using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlertController : MonoBehaviour
{
    [SerializeField]
    Player player;
    Renderer renderer;

    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        player.OnNewPickup.AddListener(TurnOff);
        player.OnDropoffComplete.AddListener(TurnOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void TurnOn(){
        renderer.enabled = true;
    }

    void TurnOff(Pickup p){
        renderer.enabled = false;
    }
}
