using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {
    private void Start()
    {
        curTimer = EnemySpawnTimer;
    }
    [SerializeField]
    private Transform EnemyObj;

    [SerializeField]
    private Datas dT;
    
    public float EnemySpawnTimer;

    private float curTimer;

    [SerializeField]
    private float SpawnDistance;

    private void Update()
    {
        if(dT.curEnemy == null)
        {
            
            if (curTimer < 0)
            {
                Vector3 spawnPos = dT.Player.position;
                spawnPos = new Vector3(spawnPos.x,spawnPos.y,spawnPos.z - SpawnDistance); 
                dT.curEnemy = Instantiate(EnemyObj, spawnPos, Quaternion.identity);
                curTimer = EnemySpawnTimer;
            }
            curTimer -= Time.deltaTime;

        }


    }

}
