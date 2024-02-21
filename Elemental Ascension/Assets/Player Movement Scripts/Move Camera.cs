using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Link: https://www.youtube.com/watch?v=f473C43s8nE&t=244s 

public class MoveCamera : MonoBehaviour
{
    public Transform cameraPosition;

    private void Update()
    {
        transform.position = cameraPosition.position;
    }
}
