using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    private static PlayerHealth _instance;
    public static PlayerHealth Instance { get { return _instance; } }
    public int maxHealth = 30;
    public int currentHealth;
    public TMP_Text healthText;

    // player hit sfx
    public AudioClip[] hits;
    void Start()
    {
        currentHealth = maxHealth;
        updateHealthText();
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
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        updateHealthText();
        // play damage sfx
        this.GetComponent<AudioSource>().PlayOneShot(hits[Random.Range(0,3)]);

        if(currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }
    public void updateHealthText()
    {
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
