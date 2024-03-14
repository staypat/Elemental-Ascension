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
