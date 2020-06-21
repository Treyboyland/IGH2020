using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyOnSceneName : MonoBehaviour
{
    [SerializeField]
    string sceneName = null;

    // Start is called before the first frame update
    void Start()
    {
        SceneManager.sceneLoaded += PerformCheck;
    }

    void PerformCheck(Scene scene, LoadSceneMode mode)
    {
        Debug.LogWarning(scene.name);
        if (scene.name == sceneName)
        {
            Destroy(gameObject);
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= PerformCheck;
    }
}
