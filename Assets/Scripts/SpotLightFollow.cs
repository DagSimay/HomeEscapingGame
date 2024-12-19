using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotLightFollow : MonoBehaviour
{
    public Transform cam;
    private float spotLightOffSet = 0.1f;
     
    
    
    void Update()
    {
        transform.position = cam.position + cam.forward * spotLightOffSet;
        transform.rotation = cam.rotation;
        transform.forward = cam.forward.normalized;
    }
}
