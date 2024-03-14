using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerAttack : MonoBehaviour
{
    public GameObject HitBox; // Set Hitbox GameObject
    public GameObject ParryHitbox; // Set ParryHitbox GameObject
    public Image CooldownBoxAttack;
    public Image CooldownBoxParry;
    public TMP_Text cooldownTextAttack;
    public TMP_Text cooldownTextParry;

    public float attackCooldown = 0.6f;
    public float parryCooldown = 3f;

    private bool canAttack;
    private bool canParry;
    public bool Attacking;
    public bool Parrying;

    // Sounds
    public AudioClip[] swings;
    public AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        canParry = true;
        CooldownBoxAttack.fillAmount = 1f;
        CooldownBoxParry.fillAmount = 1f;
        cooldownTextAttack.gameObject.SetActive(false);
        cooldownTextParry.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left Click
        {
            StartCoroutine(ActivateHitbox());
            
        }
        if (Input.GetMouseButtonDown(1)) // Right Click
        {
            StartCoroutine(ActivateParryHitbox());
        }
    }

    IEnumerator ActivateHitbox()
    {
        if(canAttack)
        {
            Attacking = true;
            // Play random swing sfx
            audioSource.PlayOneShot(swings[Random.Range(0, 2)], 0.7f);
            canAttack = false;
            HitBox.SetActive(true);
            cooldownTextAttack.gameObject.SetActive(true);
            cooldownTextAttack.text = attackCooldown.ToString();
            while (CooldownBoxAttack.fillAmount > 0)
            {
                CooldownBoxAttack.fillAmount -= Time.deltaTime / attackCooldown;
                cooldownTextAttack.text = (CooldownBoxAttack.fillAmount * attackCooldown).ToString("F1");
                yield return null;
            }
            CooldownBoxAttack.fillAmount = 1f;
            canAttack = true;
            cooldownTextAttack.gameObject.SetActive(false);
            HitBox.SetActive(false);
        }
        
    }

    IEnumerator ActivateParryHitbox()
    {
        if (canParry)
        {
            Parrying = true;
            canParry = false;
            ParryHitbox.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            cooldownTextParry.gameObject.SetActive(true);
            cooldownTextParry.text = parryCooldown.ToString();
            ParryHitbox.SetActive(false);
            while (CooldownBoxParry.fillAmount > 0)
            {
                CooldownBoxParry.fillAmount -= Time.deltaTime / parryCooldown;
                cooldownTextParry.text = (CooldownBoxParry.fillAmount * parryCooldown).ToString("F1");
                yield return null;
            }
            CooldownBoxParry.fillAmount = 1f;
            cooldownTextParry.gameObject.SetActive(false);
            canParry = true;
        }
    }
}
