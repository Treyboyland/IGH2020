using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField]
    TaskTracker tracker = null;

    [SerializeField]
    PlayerControl player = null;

    [SerializeField]
    GameObject gameBlocker = null;

    [SerializeField]
    float secondsToWait = 6.0f;

    // Start is called before the first frame update
    void Start()
    {
        gameBlocker.SetActive(false);
        tracker.OnCheckPassed.AddListener((passed) =>
        {
            if(!passed)
            {
                StartCoroutine(StartEndGameProcessing());
            }
        });
    }

    IEnumerator StartEndGameProcessing()
    {
        //Is this set really necessary?
        tracker.SecondsUntilNextCheck = 0;
        gameBlocker.SetActive(true);
        player.CanMove = false;

        yield return new WaitForSeconds(secondsToWait);

        Application.Quit();
    }
}
