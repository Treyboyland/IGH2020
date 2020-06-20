using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class ButtonCombinationLetter : MonoBehaviour
{
    [SerializeField]
    Color normalColor = Color.black;

    [SerializeField]
    Color completedColor = Color.black;

    TextMeshProUGUI textBox;

    public int Index = 0;

    string character = "";

    public string Character
    {
        get
        {
            return character;
        }
        set
        {
            character = value;
            textBox = textBox == null ? GetComponent<TextMeshProUGUI>() : textBox;
            if (textBox != null)
            {
                textBox.text = character;
            }
        }
    }

    public void SolvedCombination(int index)
    {

        textBox = textBox == null ? GetComponent<TextMeshProUGUI>() : textBox;
        if (textBox != null)
        {
            textBox.color = index > Index ? completedColor : normalColor;
        }

    }
}
