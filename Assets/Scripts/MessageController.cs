using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TextMeshProUGUI))]
public class MessageController : MonoBehaviour
{
    TextMeshProUGUI textBox;

    TaskTracker tracker;

    [SerializeField]
    Player player = null;

    int processedCount = 0;

    string[] tutorialText = new string[] {
        "Welcome to the Pickwell family! Move to the center bin with ←↑↓→ and copy the content code to pick up your first item.",
        "You're a quick learner! Now take the content to the bin with the matching color and re-enter the code to drop it off.",
        "We have a lot of content to deliver, so make sure not to let your rate on the left fall below the target.",
        "Every 60 seconds we conduct a performance review to make sure you're meeting our high standards.",
        "Unfortunately if you fall behind at a performance review (process rate in red), I'm afraid we'll have to let you go :/",
        "To maximize efficiency and professionalism, we've taken the liberty to change your name to 5265736f75726365."
    };

    string[] feedbackText = new string[] {
        "You are a crucial and valued resource, 5265736f75726365.",
        "Remember to be a team player!",
        "Pat yourself on the back: you're making the world better by helping us fulfill our mission of connecting people.",
        "Keep up the good work 5265736f75726365, and remember not to slack off. Someone might be watching!",
        "#lifehack: if you sleep in parking lots, you can save big on rent and start building wealth for the future.",
        "Your activities are being recorded for quality assurance.",
        "Did you know: Pickwell Solutions is the #1 choice of platform in over 66 countries. Not bad!",
        "Wow 5265736f75726365, your picking game is ~on~ ~fleek~",
        "Try humming a little tune while you work! Studies show humming can increase productivity by almost 4.9%",
        "Keep on delivering content!"
    };

    string failureText = "It is with deepest regrets that I inform you that your position has been eliminated effective immediately.";


    // Start is called before the first frame update
    void Start()
    {
        textBox = GetComponent<TextMeshProUGUI>();
        tracker = GetComponentInParent<TaskTracker>();
        player.OnDropsUpdated.AddListener(Dropoff);
        player.OnNewPickup.AddListener(Pickup);
        tracker.OnGameFailed.AddListener(FailState);

        textBox.text = tutorialText[0];
    }

    void Pickup(Pickup p){
        switch (processedCount){
            case 0: textBox.text = tutorialText[1]; return;
            case 1: textBox.text = tutorialText[3]; return;
            
            default: break;
        }
    }

    void Dropoff(int count){
        processedCount = count;

        switch (processedCount){
            case 1: textBox.text = tutorialText[2]; return;
            case 2: textBox.text = tutorialText[4]; return;
            case 3: textBox.text = tutorialText[5]; return;
            
            default: break;
        }

        if (processedCount > 3 && Random.value > 0.5f){
            textBox.text = feedbackText[Random.Range(0, feedbackText.Length)];
        }
    }

    void FailState(){
        textBox.text = failureText;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
