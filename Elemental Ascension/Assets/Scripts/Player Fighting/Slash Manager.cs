using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashManager : MonoBehaviour
{
    public AudioClip[] hits;
    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            EnemyAI enemyAI = other.GetComponent<EnemyAI>();
            if (enemyAI != null)
            {
                enemyAI.TakeDamage(50);
            }
            else
            {
                GolemAI golemAI = other.GetComponent<GolemAI>();
                if (golemAI != null)
                {
                    golemAI.TakeDamage(50);
                }
                else
                {
                    Debug.Log("Make sure the AI script is used!");
                }
            }
            audioSource.PlayOneShot(hits[Random.Range(0, 2)], 0.7f);
        }
    }
}
