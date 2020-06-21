using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerNameText : MonoBehaviour
{
    TextMeshProUGUI textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        textBox.text = "Name: " + GameConstants.InputName;
    }

    void SetRandomIntegerName()
    {
        textBox.text = "E-" + UnityEngine.Random.Range(0, 100000).ToString().PadLeft(5, '0');
        GameConstants.CurrentName = textBox.text;
    }
}
