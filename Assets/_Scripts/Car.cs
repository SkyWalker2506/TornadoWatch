using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    public bool IsCarActive = true;


    void FixedUpdate()
    {
        if(IsCarActive)
        Move();
    }


    void Move()
    {
        transform.position += transform.forward * Time.deltaTime* MainManager.Instance.ConstantMoveSpeed;  
    }
}
