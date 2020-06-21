using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RateCheckSounds : MonoBehaviour
{
    [SerializeField]
    TaskTracker tracker;

    [SerializeField]
    AudioClip goodClip;

    [SerializeField]
    float goodVolume;

    [SerializeField]
    AudioClip badClip;

    [SerializeField]
    float badVolume;



    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        tracker.OnCheckPassed.AddListener((passed) =>
        {
            var clip = passed ? goodClip : badClip;
            var volume = passed ? goodVolume : badVolume;
            audioSource.PlayOneShot(clip, volume);
        });
    }
}
