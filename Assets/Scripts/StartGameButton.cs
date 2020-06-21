using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

[RequireComponent(typeof(Button))]
public class StartGameButton : MonoBehaviour
{
    [SerializeField]
    string sceneName = null;

    [SerializeField]
    TMP_InputField inputField = null;

    Button button;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(StartGame);
    }

    void StartGame()
    {
        var playerName = inputField.text.ToUpper();
        Debug.Log("Player name: " + playerName);
        GameConstants.CurrentName = playerName;
        GameConstants.InputName = playerName;
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
}
