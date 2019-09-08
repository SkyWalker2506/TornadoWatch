using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnTrigger : MonoBehaviour
{
    Road road;
    bool carPassed;
    bool tornadoPassed;
    bool carEntered;
    bool tornadoEntered;
    private void Start()
    {
        road = MainManager.Instance.Road;
}

    private void OnTriggerExit(Collider other)
    {
        if (!(other.transform.root.GetComponent<Car>() || other.transform.root.GetComponent<Tornado>()))
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Car>() && carPassed)
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Tornado>() && tornadoPassed)
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Car>())
        {
            Vector3 angle = MainManager.Instance.Camera.transform.rotation.eulerAngles;
            angle.x = road.GetNextPlatform().StartPoint.transform.rotation.eulerAngles.x + 20;
            angle.y = road.GetNextPlatform().StartPoint.transform.rotation.eulerAngles.y;
            StartCoroutine(MainManager.Instance.Camera.transform.LerpToRotation(Quaternion.Euler(angle), 1));
            print(other.name);
            carPassed = true;
        }
        else if (other.transform.root.GetComponent<Tornado>())
        {
            MainManager.Instance.tornadoController.IsTouchActive = false;
            print(other.name);
            tornadoPassed = true;
        }

        print(other.name);

        Vector3 rotation = road.GetNextPlatform().StartPoint.transform.rotation.eulerAngles;
        rotation.x = 0;
        rotation.z = 0;

        print(other.transform.rotation);
        StartCoroutine(other.transform.root.LerpToRotation(Quaternion.Euler(rotation), .3f));
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!(other.transform.root.GetComponent<Car>() || other.transform.root.GetComponent<Tornado>()))
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Car>() && carEntered)
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Tornado>() && tornadoEntered)
        {
            print(other.name);
            return;
        }
        else if (other.transform.root.GetComponent<Car>())
        {
            Vector3 angle = MainManager.Instance.Camera.transform.rotation.eulerAngles;
            angle.x = road.GetNextPlatform().StartPoint.transform.rotation.eulerAngles.x + 20;
            StartCoroutine(MainManager.Instance.Camera.transform.LerpToRotation(Quaternion.Euler(angle), 1));
            print(other.name);
            carEntered = true;

        }
        else if (other.transform.root.GetComponent<Tornado>())
        {
            print(other.name);
            tornadoEntered = true;
        }
        print(other.name);
        //StartCoroutine(other.transform.root.LerpToRotation( transform.rotation, .1f));

        print(other.transform.rotation);
    }


}
