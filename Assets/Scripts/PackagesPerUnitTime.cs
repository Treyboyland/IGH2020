using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PackagesPerUnitTime : MonoBehaviour
{
    [SerializeField]
    float seconds = 0.0f;

    [SerializeField]
    Player player = null;

    TextMeshProUGUI textBox;

    float elapsed = 0.0f;

    TaskTracker tracker;

    [SerializeField]
    Material textMat;
    Color green = new Color(19 / 255.0f, 161 / 255.0f, 43 / 255.0f);
    bool passing = true;

    public BoolEvent OnPassingChanged = new BoolEvent();

    private void Start()
    {
        tracker = GetComponentInParent<TaskTracker>();
        textBox = GetComponent<TextMeshProUGUI>();

        tracker.OnCheckPlayerRate.AddListener(CheckRate);
    }

    void CheckRate()
    {
        tracker.OnCheckPassed.Invoke(GetRate() >= tracker.TargetRate);
    }


    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (GetRate() >= tracker.TargetRate && !passing)
        {
            textMat.SetColor("_FaceColor", green);
            passing = true;
            OnPassingChanged.Invoke(passing);
        }
        else if (GetRate() < tracker.TargetRate && passing)
        {
            textMat.SetColor("_FaceColor", Color.red);
            passing = false;
            OnPassingChanged.Invoke(passing);
        }

        //Technically inefficient
        textBox.text = "Rate: " + GetRate().ToString("0.00") + " / " + tracker.TargetRate.ToString("0.00") + Environment.NewLine + "connections per minute";

    }

    public float GetRate()
    {
        return (player.TotalDropsCompleted / (elapsed / seconds));
    }
}
