using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class PlayerProcessedCount : MonoBehaviour
{
    [SerializeField]
    Player player;

    TextMeshProUGUI textBox;


    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        player.OnDropsUpdated.AddListener(SetProcessedCount);

        SetProcessedCount(player.DropsCompleted);
    }

    void SetProcessedCount(int count)
    {
        textBox.text = "Processed: " + count;
    }
}
