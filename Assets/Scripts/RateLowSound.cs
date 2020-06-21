using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class RateLowSound : MonoBehaviour
{
    [SerializeField]
    TaskTracker tracker = null;

    [SerializeField]
    Player player = null;

    [SerializeField]
    PackagesPerUnitTime currentRate = null;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (audioSource.isPlaying && currentRate.GetRate() > tracker.TargetRate)
        {
            audioSource.Stop();
        }
        else if (!audioSource.isPlaying && currentRate.GetRate() < tracker.TargetRate)
        {
            audioSource.Play();
        }
    }


}
