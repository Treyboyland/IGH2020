using System.Collections;
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

        //Technically inefficient
        textBox.text = "Rate: " + GetRate().ToString("0.00") + " packages";
    }

    public float GetRate()
    {
        return (player.TotalDropsCompleted / (elapsed / seconds));
    }
}
