using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwap : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera startingCam;
    public Camera playerCam;
    void Start()
    {
        playerCam.gameObject.SetActive(false);
        startingCam.gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void switchCamera()
    {
        playerCam.gameObject.SetActive(true);
        startingCam.gameObject.SetActive(false);
    }
}
