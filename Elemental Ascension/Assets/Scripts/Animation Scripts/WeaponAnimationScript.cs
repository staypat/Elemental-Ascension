using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimationScript : MonoBehaviour
{
    // public Animation idleAnim;
    // public Animation attackAnim;
    public Animation anim;
    public AnimationClip idleClip;
    public AnimationClip attackClip;
    bool idle = true;
    bool isSwinging = false;
    bool isParrying = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animation>();
        anim.AddClip(idleClip, "Idle");
        anim.AddClip(attackClip, "Weapon Swing");
    }

    // Update is called once per frame
    void Update()
    {

        // ----- Attack Animation START -----

            // If the player presses the left mouse button, play the attack animation
            if (Input.GetMouseButtonDown(0))
            {
                if (idle)
                {
                    idle = false;
                    isSwinging = true;                    
                    GetComponent<Animation>().Stop("Idle");
                    GetComponent<Animation>().Play("Weapon Swing");
                    Debug.Log("Swinging Start");
                }
            }

            // If the swing animation has finished playing, set isSwinging to false
            else if (!GetComponent<Animation>().IsPlaying("Weapon Swing")) // Add this line
            {
                isSwinging = false; // Add this line
                idle = true;
                GetComponent<Animation>().Stop("Weapon Swing");
                GetComponent<Animation>().Play("Idle");
            }

        // ----- Attack Animation END -----

        // ----- Parry Animation START -----

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
            // if (!GetComponent<Animation>().IsPlaying("Parry") && isParrying) // Add this line
            // {
            //     idle = true;
            //     isParrying = false;
            //     GetComponent<Animation>().Stop("Parry");
            //     GetComponent<Animation>().Play("Idle"); 
            // }

        // ----- Parry Animation END -----


    }
}
