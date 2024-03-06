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
        // If the player presses the left mouse button, play the attack animation
        if (Input.GetMouseButtonDown(0))
        {
            if (idle)
            {
                GetComponent<Animation>().Stop("Idle");
                GetComponent<Animation>().Play("Weapon Swing");
                idle = false;
                isSwinging = true;
            }
        }

        // If the swing animation has finished playing, set isSwinging to false
        if (!GetComponent<Animation>().IsPlaying("Weapon Swing")) // Add this line
        {
            isSwinging = false; // Add this line
            idle = true;
            GetComponent<Animation>().Stop("Weapon Swing");
            GetComponent<Animation>().Play("Idle");
        }
    }
}
