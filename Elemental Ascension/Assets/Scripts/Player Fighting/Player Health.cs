using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Start is called before the first frame update
    public int maxHealth = 30;
    private int currentHealth;
    public TMP_Text healthText;
    public TMP_Text GameOverText;
    void Start()
    {
        currentHealth = maxHealth;
        updateHealthText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void takeDamage(int damage)
    {
        currentHealth -= damage;
        updateHealthText();
        if(currentHealth <= 0)
        {
            GameOverText.gameObject.SetActive(true);
        }
    }
    public void updateHealthText()
    {
        healthText.text = currentHealth.ToString() + "/" + maxHealth.ToString();
    }
}
