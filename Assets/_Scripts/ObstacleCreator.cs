using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ObstacleCreator : MonoBehaviour
{
    [Tooltip("Choose a building block from prefabs")]
    [SerializeField]
    BuildingBlock buildingBlock;
    [Tooltip("Choose a material for the blocks")]
    [SerializeField]
    Material buildingBlockMaterial;
    [Tooltip("Choose the legth of the obstacle")]
    [SerializeField]
    [Range(1,100)]
    int lengthOfTheObstacle=1;
    [Tooltip("Choose the height of the obstacle")]
    [SerializeField]
    [Range(1, 100)]
    int heightOfTheObstacle=1;
    [Tooltip("Choose the depth of the obstacle")]
    [SerializeField]
    [Range(1, 100)]
    int depthOfTheObstacle=1;
    [Tooltip("Choose the height of the obstacle")]
    [SerializeField]
    [Range(1, 10)]
    float spaceBetweenBlocks = 0;



    [ContextMenu("Create Obstacle")]
    public void CreateObstacle()
    {
        if (!buildingBlock)
            return;
        GameObject bb = new GameObject();
        bb = buildingBlock.gameObject;
        bb.name = buildingBlock.name;
        bb.GetComponent<MeshRenderer>().material = buildingBlockMaterial;
        GameObject obstacle = new GameObject();
        obstacle.name = buildingBlock.name+ " " + lengthOfTheObstacle+"x"+ heightOfTheObstacle+ "x" + depthOfTheObstacle;
        Transform obsTransform=obstacle.transform;

        for (int z = 0; z < depthOfTheObstacle; z++)
        {
            for (int y = 0; y < heightOfTheObstacle; y++)
            {
                for (int x = 0; x < lengthOfTheObstacle; x++)
                {
                    Instantiate(buildingBlock.gameObject, obsTransform).transform.position = new Vector3(x, y, z) * spaceBetweenBlocks;
                }
            }
        }
        Destroy(bb);
    }
}
