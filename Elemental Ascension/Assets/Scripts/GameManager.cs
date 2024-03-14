using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static int level;
    public int playerHP;

    public static GameManager Instance { get { return _instance; } }
    // Start is called before the first frame update
    void Start()
    {
        level = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void OnEnable()
    {
        // Subscribe to the sceneLoaded event
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnDisable()
    {
        // Unsubscribe from the sceneLoaded event
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    // This method will be called every time a new scene is loaded
    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Check if the player exists in the scene
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            // Disable and re-enable player scripts
            PlayerMovement playerMovement = player.GetComponent<PlayerMovement>();
            if (playerMovement != null)
            {
                playerMovement.enabled = false;
                playerMovement.enabled = true;
                playerMovement.readyToJump = true;
                playerMovement.grounded = true;
            }
            if (scene.name == "1-1")
            {
                Debug.Log("Loaded scene 1-1");
                player.transform.position = new Vector3(97, 4, 47);
            }
            else if (scene.name == "1-2")
            {
                player.transform.position = new Vector3(4, 2, -16);
            }
            else if (scene.name == "1-3")
            {
                player.transform.position = new Vector3(174, 2, 45);
            }
            else if (scene.name == "2-1")
            {
                player.transform.position = new Vector3(141, 20, 81);
            }
            else if (scene.name == "3-1")
            {
                player.transform.position = new Vector3(216, 27, 123);
            }
        }
    }
}
