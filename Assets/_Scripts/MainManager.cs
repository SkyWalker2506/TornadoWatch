using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance;

    public Transform Tornado;
    public TornadoController tornadoController;

    public Transform Car;
    public Camera Camera;
    public Road Road;
    [Tooltip("This determines the constant movement speed for the car and the tornado")]
    public float ConstantMoveSpeed = 5;

    [Tooltip("This is the start point of the level. Car start from this postion and move towards the rotation of this object.")]
    [SerializeField]
    Transform startPoint;


    private void Awake()
    {
        Initialize();

        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Initialize()
    {
        if (!Tornado)
            Tornado = FindObjectOfType<Tornado>().transform.root;
        if (!tornadoController)
            tornadoController = FindObjectOfType<TornadoController>();
        if (!Car)
            Car = FindObjectOfType<Car>().transform;
        if (!Camera)
            Camera = Camera.main;
        if (!Road)
            Road = FindObjectOfType<Road>();
        startPoint = Road.Platforms[0].StartPoint.transform;
        Car.position = startPoint.position;
        Car.rotation = startPoint.rotation;
      //  Camera.transform.LookAt(Car.transform);
        Tornado.rotation = startPoint.rotation;
        Tornado.position = startPoint.position + Tornado.forward * 10;
    }

    public void SetCamaraAngle(int platform)
    {
        Vector3 rotation = Camera.transform.rotation.eulerAngles;
        rotation.x = Road.Platforms[platform].StartPoint.transform.rotation.eulerAngles.x + 20;
        rotation.y = Road.Platforms[platform].StartPoint.transform.rotation.eulerAngles.y;
        Camera.transform.rotation = Quaternion.Euler(rotation);
    }


    public void WinTheGame()
    {
        StopGamePlay();
        UIManager.Instance.ShowWinScreen();
    }

    public void LostTheGame()
    {
        StopGamePlay();
        UIManager.Instance.ShowLoseScreen();
    }

    void StopGamePlay()
    {
        tornadoController.IsControllerActive=false;
        Car.GetComponent<Car>().IsCarActive = false;
    }


}
