using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class BuildingBlock : MonoBehaviour
{
    Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.Sleep();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.root.GetComponent<Car>())
        {
            MainManager.Instance.LostTheGame();
        }
    }

}
