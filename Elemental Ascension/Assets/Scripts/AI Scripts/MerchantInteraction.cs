using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MerchantInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hasTriggered = false;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (!hasTriggered && other.CompareTag("Player"))
        {
            PlayerHealth.Instance.currentHealth += 20;
            UpdateHealthUIText();
            hasTriggered = true;
        }
    }
    private void UpdateHealthUIText()
    {
        GameObject healthTextObject = GameObject.FindGameObjectWithTag("UI");
        if (healthTextObject != null)
        {
            TMP_Text healthText = healthTextObject.GetComponent<TMP_Text>();
            if (healthText != null)
            {
                if(PlayerHealth.Instance.maxHealth < PlayerHealth.Instance.currentHealth)
                {
                    PlayerHealth.Instance.maxHealth = PlayerHealth.Instance.currentHealth;
                }
                healthText.text = PlayerHealth.Instance.currentHealth.ToString() + "/" + PlayerHealth.Instance.maxHealth.ToString();
            }
        }
    }
}
