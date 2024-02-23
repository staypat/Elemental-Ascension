using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDamageScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int damageAmount = 5;
    //public 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerHealth>().takeDamage(damageAmount);
            Destroy(this.gameObject);
        }
        
    }
}
