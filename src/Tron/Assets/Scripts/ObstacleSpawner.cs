using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour {

    [SerializeField]
    private EndlessRoadScript endlessScript;

    [SerializeField]
    private Transform[] Obstacles;

    [SerializeField]
    [Tooltip("Must be between 0-100")]
    private int ObstacleFreq;

    [SerializeField]
    private Datas dT;

    public bool canCreate;
    [SerializeField]
    private int nonObstacleZoneAmount;

    public void SpawnObstacle(float width)
    {
        int SpawnChance = Random.Range(0, 100);

        if(SpawnChance < ObstacleFreq && dT.curEnemy == null )
        {
            nonObstacleZoneAmount--;
            Vector3 roadPos = endlessScript.curRoadPos;
            float spawnLocX = Random.Range(-width,width);
            Vector3 newObstaclePos = new Vector3(spawnLocX,0, roadPos.z);

            //TODO: ADD RANDOMIZATION OF THE OBSTACLES HERE
            int i = Random.Range(0, Obstacles.Length);

            if (canCreate && nonObstacleZoneAmount < 0)
            {
                Instantiate(Obstacles[i], newObstaclePos, Quaternion.identity);
            }
            
        }

    }

}
