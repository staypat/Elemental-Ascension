using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryScript : MonoBehaviour
{
    public Animation anim;
    public AnimationClip parryClip;
    bool idle = true;
    bool isParrying = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.AddClip(parryClip, "Parry");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StartCoroutine(PlayParryAnimation());
        }
        
        // // If the player presses the right mouse button, play the parry animation
        // if (Input.GetMouseButtonDown(1))
        // {
        //     if (idle)
        //     {
        //         idle = false;
        //         isParrying = true;
        //         GetComponent<Animation>().Stop("Idle");
        //         GetComponent<Animation>().Play("Parry");
        //         Debug.Log("Parrying Start");

        //     }
        // }

        // // If the parry animation has finished playing, set Parry to false
        // if (!GetComponent<Animation>().IsPlaying("Parry")) // Add this line
        // {
        //     idle = true;
        //     isParrying = false;
        //     GetComponent<Animation>().Stop("Parry");
        //     GetComponent<Animation>().Play("Idle"); 
        // }
    }

    IEnumerator PlayParryAnimation()
    {
        idle = false;
        isParrying = true;
        GetComponent<Animation>().Stop("Idle");
        GetComponent<Animation>().Play("Parry");
        Debug.Log("Parrying Start");

        // Wait for the length of the parry animation
        yield return new WaitForSeconds(GetComponent<Animation>()["Parry"].length);

        // After the parry animation has finished playing, set Parry to false
        idle = true;
        isParrying = false;
        GetComponent<Animation>().Stop("Parry");
        GetComponent<Animation>().Play("Idle");
    }
}
