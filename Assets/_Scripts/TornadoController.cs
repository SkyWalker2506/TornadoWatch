using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoController : MonoBehaviour
{
    [Tooltip("It is the maximum amount of drag that controller will be accept. It can be seen as maximum accelaration limit")]
    [SerializeField]
    float limitMovementMagnitude = 100;
    [Tooltip("Movement speed of the tornado")]
    [SerializeField]
    float moveSpeed;
    public bool IsControllerActive=true;
    public bool IsTouchActive = true;

    Vector2 lastTouchPosition;


    public void FixedUpdate()
    {
        if (!IsControllerActive)
            return;
        MainManager.Instance.Tornado.position += MainManager.Instance.Tornado.root.forward * Time.deltaTime * MainManager.Instance.ConstantMoveSpeed;
        
        if (!IsTouchActive)
            return;

        if (Input.GetMouseButtonDown(0))
        {
             lastTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            MoveTornado(GetScreenDelta());
            lastTouchPosition = Input.mousePosition;
        }
    }

    Vector2 GetScreenDelta()
    {
        Vector2 screenDelta = (Vector2)Input.mousePosition - lastTouchPosition;

        //If there is an anomaly of the screenDelta value this part
        if (screenDelta.magnitude > limitMovementMagnitude)
            return screenDelta/ screenDelta.magnitude* limitMovementMagnitude;
        else
            return screenDelta;
    }


    void MoveTornado(Vector2 screenDelta)
    {
        Transform camera = Camera.main.transform;
        Vector3 direction = camera.forward * screenDelta.y + camera.right * screenDelta.x;
        direction.y = 0;
        MainManager.Instance.Tornado.position += direction * moveSpeed * Time.fixedDeltaTime;
    }


}
