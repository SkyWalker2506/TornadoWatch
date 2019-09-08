using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    Transform target;
    [SerializeField]
    Vector3 distance;
    [SerializeField]
    float speed=1;



    void FixedUpdate()
    {
        Follow(target);

    }
    
    void Follow(Transform target)
    {
        //transform.LookAt(target);
        //Vector3 direction = target.position - transform.position;
        //transform.LerpToRotation(target.rotation,1f);

        Vector3 pos = target.right * distance.x + -target.up * distance.y - target.forward * distance.z;
        transform.position = target.position - pos;
    }



}
