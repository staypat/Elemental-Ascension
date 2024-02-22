using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject HitBox; // Set Hitbox GameObject
    public GameObject ParryHitbox; // Set ParryHitbox GameObject
    
    // Start is called before the first frame update
    void Start()
    {
        
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
        HitBox.SetActive(true);
        yield return new WaitForSeconds(1f);
        HitBox.SetActive(false);
    }

    IEnumerator ActivateParryHitbox()
    {
        ParryHitbox.SetActive(true);
        yield return new WaitForSeconds(0.2f);
        ParryHitbox.SetActive(false);
    }
    
}
