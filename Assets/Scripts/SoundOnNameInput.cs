using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class SoundOnNameInput : MonoBehaviour
{
    [SerializeField]
    TMP_InputField inputField = null;

    [SerializeField]
    float volume = 1;

    [SerializeField]
    AudioClip clip;

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        inputField.onValueChanged.AddListener((unused) =>
        {
            audioSource.PlayOneShot(clip, volume);
        });
    }
}
