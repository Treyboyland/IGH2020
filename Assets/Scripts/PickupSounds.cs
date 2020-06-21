using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickupSounds : MonoBehaviour
{
    [SerializeField]
    Player player = null;

    [SerializeField]
    AudioClip pickupClip = null;

    [SerializeField]
    float pickupVolume = 1;

    [SerializeField]
    AudioClip dropoffClip = null;

    [SerializeField]
    float dropoffVolume = 1;

    AudioSource audioSource;


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        player.OnDropoffStarted.AddListener(() =>
        {
            audioSource.PlayOneShot(dropoffClip, dropoffVolume);
        });

        player.OnNewPickup.AddListener((unused) =>
        {
            audioSource.PlayOneShot(pickupClip, pickupVolume);
        });
    }
}
