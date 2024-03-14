using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StairsMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rigidBody;
    public GameObject stepRayUpper;
    public GameObject stepRayLower;
    public float stepHeight = 0.3f;
    public float stepSmooth = 0.1f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        stepClimb();
    }
    private void Awake()    
    {
        stepRayUpper.transform.position = new Vector3(stepRayUpper.transform.position.x, stepHeight, stepRayUpper.transform.position.z);
    }
    void stepClimb()
    {
        RaycastHit hitLower;
        if(Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward), out hitLower, 0.1f))
        {
            Debug.DrawRay(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward) * hitLower.distance, Color.green);
<<<<<<< Updated upstream
            RaycastHit hitUpper;    
            if(!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
=======
<<<<<<< HEAD
            RaycastHit hitUpper;
            if(!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.5f))
=======
            RaycastHit hitUpper;    
            if(!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(Vector3.forward), out hitUpper, 0.2f))
>>>>>>> 286b4824f412bd4cd14f6640cefdba5787fad242
>>>>>>> Stashed changes
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
        else
        {
            Debug.DrawRay(stepRayLower.transform.position, transform.TransformDirection(Vector3.forward) * 2f, Color.red);
        }
        RaycastHit hitLower45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitLower45, 0.5f))
        {
            RaycastHit hitUpper45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(1.5f, 0, 1), out hitUpper45, 1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
        Debug.DrawRay(stepRayLower.transform.position, transform.TransformDirection(1.5f, 0, 1) * hitLower45.distance, Color.blue);
        RaycastHit hitLowerMinus45;
        if (Physics.Raycast(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitLowerMinus45, 0.5f))
        {
            RaycastHit hitUpperMinus45;
            if (!Physics.Raycast(stepRayUpper.transform.position, transform.TransformDirection(-1.5f, 0, 1), out hitUpperMinus45, 1f))
            {
                rigidBody.position -= new Vector3(0f, -stepSmooth, 0f);
            }
        }
        Debug.DrawRay(stepRayLower.transform.position, transform.TransformDirection(-1.5f, 0, 1) * hitLowerMinus45.distance, Color.yellow);
    }
}
