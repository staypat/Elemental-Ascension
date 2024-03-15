using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // Loading scene
    public void LoadScene(string sceneName)
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name == "Game Over" || currentScene.name == "Game Over Win") 
        {
            PlayerHealth.Instance.resetHP();
        }
        if (sceneName == "Menu")
        {
            GameManager.Instance.toggleUI(false);
        }
        else
        {
            GameManager.Instance.toggleUI(true);
        }
        Debug.Log(currentScene.name);
        SceneManager.LoadScene(sceneName);
    }

    // public string sceneToLoad;

    // // Clicking button changes scene

    // public void onClick()
    // {
    //     SceneManager.LoadScene(sceneToLoad);
    // }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
