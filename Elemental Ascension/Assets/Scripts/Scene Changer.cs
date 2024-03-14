using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public AudioClip teleport;
    [SerializeField] private string sceneName;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToScene(string sceneName)
    {
        GameManager.Instance.playerHP = PlayerHealth.Instance.currentHealth;
        SceneManager.LoadScene(sceneName);
        // Type in name of scene in inspector
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<AudioSource>().PlayOneShot(teleport, 0.7f);
            GoToScene(sceneName);
        }
    }
}
