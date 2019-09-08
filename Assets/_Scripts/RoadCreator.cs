using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadCreator : MonoBehaviour
{
    [Tooltip("Choose platforms you wanted to create")]
    [SerializeField]
    List<Platform> platforms;
    [SerializeField]
    GameObject turnPlatformPrefab;
    [SerializeField]
    GameObject endLinePrefab;
    [SerializeField]
    GameObject startPointPrefab;
    [SerializeField]
    Material defaultMaterial;

    [ContextMenu("Create Road")]
    public void CreateRoad()
    {
        GameObject Road = new GameObject("Road");
        Road.AddComponent<Road>().Platforms=platforms;
        Transform currentRoadPosition = GameObject.CreatePrimitive(PrimitiveType.Cube).transform;
        currentRoadPosition.name = "Current Road Position";
        currentRoadPosition.parent = Road.transform;
        currentRoadPosition.GetComponent<MeshRenderer>().enabled = false;
        for (int i = 0; i < platforms.Count; i++)
        {
            Transform platform = CreatePlatform(platforms[i]).transform;
            platforms[i].StartPoint = Instantiate(startPointPrefab,platform);
            platforms[i].StartPoint.transform.position = platform.position - platform.transform.forward * platforms[i].Size.z / 2+ platform.up*1.5f;
            platforms[i].StartPoint.transform.localScale =new Vector3(platforms[i].Size.x,10,.1f);
            platform.parent = Road.transform;
            platform.position = currentRoadPosition.position;
            platform.rotation = Quaternion.Euler(new Vector3(platforms[i].Angle, currentRoadPosition.rotation.eulerAngles.y, 0));
            platform.transform.position = currentRoadPosition.transform.position + platform.transform.forward* platforms[i].Size.z / 2;
            currentRoadPosition.parent = platform;
            currentRoadPosition.transform.position = platform.transform.position + platform.transform.forward * platforms[i].Size.z / 2;

            if(i< platforms.Count-1)
            {
                Transform turn = Instantiate(turnPlatformPrefab, Road.transform).transform;
                float scale = platforms[i].StartPoint.transform.localScale.x;
                turn.localScale = scale * new Vector3(1, 1/ scale, 1);
                currentRoadPosition.position += currentRoadPosition.transform.forward * turn.localScale.z / 2 ;
                turn.position = currentRoadPosition.position;
                turn.rotation = Quaternion.Euler(Vector3.up * platform.rotation.eulerAngles.y);
                if (platforms[i + 1].Turn == Turn.TurnLeft)
                    currentRoadPosition.rotation =  Quaternion.Euler(currentRoadPosition.rotation.eulerAngles +new Vector3(0, 90, 0));
                else if (platforms[i + 1].Turn == Turn.TurnRight)
                    currentRoadPosition.rotation = Quaternion.Euler(currentRoadPosition.rotation.eulerAngles + new Vector3(0, -90, 0));
                currentRoadPosition.position += currentRoadPosition.forward * turn.localScale.x / 2;
            }
            else
            {
                Transform endLine = Instantiate(endLinePrefab, Road.transform).transform;
                float scale = platforms[i].StartPoint.transform.localScale.x;
                endLine.localScale = scale * new Vector3(1, 1 / scale, 1);
                currentRoadPosition.position += currentRoadPosition.transform.forward * endLine.localScale.z / 2;
                endLine.position = currentRoadPosition.position;
                endLine.rotation = Quaternion.Euler(Vector3.up * platform.rotation.eulerAngles.y);
                if (platforms[i + 1].Turn == Turn.TurnLeft)
                    currentRoadPosition.rotation = Quaternion.Euler(currentRoadPosition.rotation.eulerAngles + new Vector3(0, 90, 0));
                else if (platforms[i + 1].Turn == Turn.TurnRight)
                    currentRoadPosition.rotation = Quaternion.Euler(currentRoadPosition.rotation.eulerAngles + new Vector3(0, -90, 0));
                currentRoadPosition.position += currentRoadPosition.forward * endLine.localScale.x / 2;
            }

        }


    }

    GameObject CreatePlatform(Platform platform)
    {
        GameObject PlatfromParent = new GameObject();
        GameObject GO = GameObject.CreatePrimitive(PrimitiveType.Cube);
        GO.transform.parent = PlatfromParent.transform;
        if (platform.Material)
            GO.GetComponent<MeshRenderer>().material = platform.Material;
        else if(defaultMaterial)
            GO.GetComponent<MeshRenderer>().material = defaultMaterial;
        GO.transform.localScale = platform.Size;
        return PlatfromParent;
    }

}
