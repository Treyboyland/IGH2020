using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class ComboButtonSounds : MonoBehaviour
{
    [SerializeField]
    ButtonCombination combination;


    AudioSource audioSource;

    [SerializeField]
    AudioClip goodClip;

    [SerializeField]
    float goodClipVolume;

    [SerializeField]
    AudioClip badClip;

    [SerializeField]
    float badClipVolume;

    [SerializeField]
    AudioClip completeClip;

    [SerializeField]
    float completeClipVolume;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        combination.OnBadButton.AddListener(() =>
        {
            audioSource.PlayOneShot(badClip, badClipVolume);
        });

        combination.OnGoodButton.AddListener(() =>
        {
            audioSource.PlayOneShot(goodClip, goodClipVolume);
        });

        combination.OnCombinationComplete.AddListener(() =>
        {
            audioSource.PlayOneShot(completeClip, completeClipVolume);
        });
    }
}
