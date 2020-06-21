using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RateLowSound : MonoBehaviour
{
    [SerializeField]
    TaskTracker tracker = null;

    [SerializeField]
    PackagesPerUnitTime currentRate = null;

    [SerializeField]
    AudioClip rateLowClip;

    AudioSource audioSource;

    const float MIN_RATE = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        currentRate.OnPassingChanged.AddListener((passing) =>
        {
            if (!passing && currentRate.GetRate() > MIN_RATE)
            {
                audioSource.PlayOneShot(rateLowClip);
            }
        });
    }

    // private void Update()
    // {
    //     if (audioSource.isPlaying && currentRate.GetRate() > tracker.TargetRate)
    //     {
    //         audioSource.Stop();
    //     }
    //     else if (!audioSource.isPlaying && currentRate.GetRate() > 0.1f && currentRate.GetRate() < tracker.TargetRate)
    //     {
    //         audioSource.Play();
    //     }
    // }


}
