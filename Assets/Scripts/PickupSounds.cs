using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class PickupSounds : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    AudioClip pickupClip;

    [SerializeField]
    float pickupVolume;

    [SerializeField]
    AudioClip dropoffClip;

    [SerializeField]
    float dropoffVolume;

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
