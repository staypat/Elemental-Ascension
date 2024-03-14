using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SpawnTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Spawner;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Spawner.SetActive(true);
        }
    }
}
