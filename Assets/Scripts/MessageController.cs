using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MessageController : MonoBehaviour
{
    TextMeshProUGUI textBox;
    TaskTracker tracker;


    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        tracker = GetComponentInParent<TaskTracker>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
