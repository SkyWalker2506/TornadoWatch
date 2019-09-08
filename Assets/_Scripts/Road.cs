using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    
    public List<Platform> Platforms;
    public int CurrentPlatfom=0;


    public Platform GetNextPlatform()
    {
        if (CurrentPlatfom >= Platforms.Count)
            return null;
        else
        {
            return Platforms[CurrentPlatfom+1];
        }
    }

    public void NextPlatform()
    {
        Debug.Log("Go to next platform");
        CurrentPlatfom++;
    }
}
