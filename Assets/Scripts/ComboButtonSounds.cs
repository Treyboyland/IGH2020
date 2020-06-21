using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ComboButtonSounds : MonoBehaviour
{
    [SerializeField]
    ButtonCombination combination = null;


    AudioSource audioSource;

    [SerializeField]
    AudioClip goodClip = null;

    [SerializeField]
    float goodClipVolume = 1.0f;

    [SerializeField]
    AudioClip badClip = null;

    [SerializeField]
    float badClipVolume = 1.0f;

    [SerializeField]
    AudioClip completeClip = null;

    [SerializeField]
    float completeClipVolume = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        combination.OnBadButton.AddListener(() =>
        {
            audioSource.PlayOneShot(badClip, badClipVolume);
        });

        // combination.OnGoodButton.AddListener(() =>
        // {
        //     audioSource.PlayOneShot(goodClip, goodClipVolume);
        // });

        // combination.OnCombinationComplete.AddListener(() =>
        // {
        //     audioSource.PlayOneShot(completeClip, completeClipVolume);
        // });
    }
}
