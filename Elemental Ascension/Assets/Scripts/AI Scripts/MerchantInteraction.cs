using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MerchantInteraction : MonoBehaviour
{
    // Start is called before the first frame update
    private bool hasTriggered = false;
    public Subtitles text;
    public GameObject portal;
    public string textFlavor;
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
            PlayerHealth.Instance.currentHealth += 35;
            portal.SetActive(true);
            hasTriggered = true;
            UpdateHealthUIText();
            text.ShowSubtitle(textFlavor);
            StartCoroutine(HideSubtitles());
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
    IEnumerator HideSubtitles()
    {
        yield return new WaitForSeconds(2f);
        text.HideSubtitle();
    }
}
