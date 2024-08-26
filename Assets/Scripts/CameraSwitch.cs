using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    public Transform target;
    public float cameraSpeed;

    private void Start()
    {
        
    }
    void Update()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = Vector3.Slerp(transform.position,new Vector3(target.position.x,target.position.y,target.position.z),cameraSpeed);
    }
}
