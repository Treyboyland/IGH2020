using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TrackerTimeRemaining : MonoBehaviour
{
    TextMeshProUGUI textBox;

    TaskTracker tracker;

    float elapsed = 0;
    float initialTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        tracker = GetComponentInParent<TaskTracker>();
        tracker.OnNewCheckTimeSet.AddListener(ResetStuff);
        ResetStuff(tracker.SecondsUntilNextCheck);
    }

    void ResetStuff(float newTime)
    {
        initialTime = newTime;
        elapsed = 0;
    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        if (elapsed >= initialTime)
        {
            tracker.OnCheckPlayerRate.Invoke();
        }
        else
        {
            float remaining = initialTime - elapsed;
            TimeSpan ts = new TimeSpan(0, 0, 0, (int)remaining, (int)((remaining % 1) * 1000));
            textBox.text = "Time Until Review: " + ts.ToString("mm\\:ss\\.fff");
        }
    }
}
