using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirTowerManager : MonoBehaviour
{
    public GameObject portal;
    private bool on;
    // Start is called before the first frame update
    void Start()
    {
        on = true;
        StartCoroutine(Check());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Check()
    {
        while (on)
        {
            yield return new WaitForSeconds(1);
            if (GameManager.level == 1 )
            {
                on = false;
                SpawnPortal();
            }
        }
    }

    public void SpawnPortal()
    {
        portal.SetActive(true);
    }
}
