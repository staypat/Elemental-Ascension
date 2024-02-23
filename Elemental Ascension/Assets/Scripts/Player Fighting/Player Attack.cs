using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject HitBox; // Set Hitbox GameObject
    public GameObject ParryHitbox; // Set ParryHitbox GameObject

    private bool canAttack;
    private bool canParry;
    
    // Start is called before the first frame update
    void Start()
    {
        canAttack = true;
        canParry = true;
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
            yield return new WaitForSeconds(1f);
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
            yield return new WaitForSeconds(0.5f);
            canParry = true;
            canAttack = true;
            ParryHitbox.SetActive(false);
        }
    }
}
