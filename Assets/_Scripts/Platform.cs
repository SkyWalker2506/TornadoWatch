using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class Platform 
{
    [Tooltip("Choose the material for the platform")]
    public Material Material;
    [Tooltip("Choose if the platform will be created left of the road or right of the road.")]
    public Turn Turn=Turn.TurnLeft;
    [Tooltip("Choose angle of the road.")]
    public float Angle;
    [Tooltip("Choose size of the platform.")]
    public Vector3 Size = new Vector3(10,1,50);
    public GameObject StartPoint;

}

[Serializable]
public enum Turn
{
    None,
    TurnLeft,
    TurnRight
}