using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndTrigger : MonoBehaviour
{

    bool carPassed;
    bool tornadoPassed;

    private void OnTriggerEnter(Collider other)
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
            print(other.name);
            carPassed = true;
            //       other.transform.root.position = transform.position;
        }
        else if (other.transform.root.GetComponent<Tornado>())
        {
            print(other.name);
            tornadoPassed = true;
            //         other.transform.root.position = new Vector3(other.transform.root.position.x, transform.position.y, other.transform.root.position.z);
        }
        other.transform.root.position = new Vector3(other.transform.root.position.x, transform.position.y, other.transform.root.position.z);
        other.enabled = false;
        other.transform.root.position = transform.position;
        new Vector3(transform.position.x, transform.position.y, other.transform.root.position.z);
        StartCoroutine(other.transform.root.LerpToRotation(transform.rotation, .5f));
        other.enabled = true;

        print(other.transform.rotation);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.root.GetComponent<Tornado>())
        {
            MainManager.Instance.tornadoController.IsControllerActive = false;
            other.enabled = false;
        }
            if (other.transform.root.GetComponent<Car>())
            MainManager.Instance.WinTheGame();
    }
}
