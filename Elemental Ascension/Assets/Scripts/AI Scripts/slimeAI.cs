using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class slimeAI : MonoBehaviour
{
    //reserved for later if we want to use this for the slime mob

    public NavMeshAgent agent;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(player.transform.position);
    }
}
