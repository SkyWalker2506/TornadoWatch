using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tornado : MonoBehaviour
{
    Transform tornado;
    [Tooltip("Decides how much force the tornado will affect the objects when spinning")]
    [SerializeField]
    float tornadoSpinForce = 20;
    [Tooltip("Decides how much force the tornado will affect the objects against gravity")]
    [SerializeField]
    float upForce=20;
    [Tooltip("Decides if tornado turn clockwise or counter clockwise. (Tornado animation not work according to this variable)")]
    [SerializeField]
    bool isClockwise;

    private void Awake()
    {
        tornado = transform;
    }

    private void OnTriggerStay(Collider other)
    {
        ApplyForce(other.transform);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<BuildingBlock>())
            Handheld.Vibrate();

        if (other.transform.root.GetComponent<Car>())
        {
            Handheld.Vibrate();
            MainManager.Instance.LostTheGame();
        }
    }

    public void ApplyForce(Transform tr)
    {
        Rigidbody rb = tr.GetComponent<Rigidbody>();
        if (!rb)
            return;

        float distance = Vector3.Distance(tr.position , tornado.position);
   
        Vector3 spinDirection = new Vector3(tornado.position.z- tr.position.z, 0,  tr.position.x - tornado.position.x).normalized;
        spinDirection = isClockwise ? -spinDirection : spinDirection;
        Vector3 force = spinDirection * tornadoSpinForce;
        force.y = upForce;
        rb.AddForce(force / Mathf.Sqrt(distance));

    }


}
