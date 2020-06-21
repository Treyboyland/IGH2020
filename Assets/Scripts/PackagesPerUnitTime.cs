﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
    Color green = new Color(19/255.0f, 161/255.0f, 43/255.0f);
    bool passing = true;

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

        if (GetRate() >= tracker.TargetRate && !passing){
            textMat.SetColor("_FaceColor", green);
            passing = true;
        }
        else if (GetRate() < tracker.TargetRate && passing){
            textMat.SetColor("_FaceColor", Color.red);
            passing = false;
        }

        //Technically inefficient
        textBox.text = "Rate: " + GetRate().ToString("0.00") + " packages / min";

    }

    public float GetRate()
    {
        return (player.TotalDropsCompleted / (elapsed / seconds));
    }
}