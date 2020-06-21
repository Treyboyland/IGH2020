using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class TargetPackagesPerUnitTime : MonoBehaviour
{
    TextMeshProUGUI textBox;

    TaskTracker tracker;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        tracker = GetComponentInParent<TaskTracker>();

        //Debug.LogWarning(tracker.TargetRate);

        tracker.OnNewTargetSet.AddListener(SetText);
        SetText(tracker.TargetRate);
    }

    void SetText(float target)
    {
        textBox.text = "Target: " + target + " packages";
    }
}
