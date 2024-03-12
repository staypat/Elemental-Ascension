using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour
{
    public GameObject HitBox; // Set Hitbox GameObject
    public GameObject ParryHitbox; // Set ParryHitbox GameObject
    public Image CooldownBoxAttack;
    public Image CooldownBoxParry;

    public float attackCooldown = 0.5f;
    public float parryCooldown = 3f;

    private bool canAttack;
    private bool canParry;
    
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        canParry = true;
        CooldownBoxAttack.fillAmount = 1f;
        CooldownBoxParry.fillAmount = 1f;
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
            canAttack = false;
            canParry = false;
            HitBox.SetActive(true);
            while (CooldownBoxAttack.fillAmount > 0)
            {
                CooldownBoxAttack.fillAmount -= Time.deltaTime / attackCooldown;
                yield return null;
            }
            CooldownBoxAttack.fillAmount = 1f;
            canAttack = true;
            canParry = true;
            HitBox.SetActive(false);
        }
        
    }

    IEnumerator ActivateParryHitbox()
    {
        if (canParry)
        {
            canParry = false;
            canAttack = false;
            ParryHitbox.SetActive(true);
            yield return new WaitForSeconds(1.0f);
            canAttack = true;
            ParryHitbox.SetActive(false);
            while (CooldownBoxParry.fillAmount > 0)
            {
                CooldownBoxParry.fillAmount -= Time.deltaTime / parryCooldown;
                yield return null;
            }
            CooldownBoxParry.fillAmount = 1f;
            canParry = true;
        }
    }
}
