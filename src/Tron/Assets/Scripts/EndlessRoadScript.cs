using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessRoadScript : MonoBehaviour
{

    [SerializeField]
    private Transform[] roads;
    /*
     0 -> Normal Road
     1 -> Thin road
     */

    [SerializeField]
    private Datas dat;
    private Vector3 Player;
    public Vector3 curRoadPos;
    [SerializeField]
    private float roadSpawnInterval;
    [SerializeField]
    private int RoadNeededAhead;
    public bool IsThin = false;
    public bool createdTransitionforward = false;
    public bool createdTransitionbackward = false;
    [SerializeField]
    private ObstacleSpawner obsSpawner;



    private void Update()
    {
        if (dat.Player != null)
        {
            Player = dat.Player.position;
            // Debug.Log(curRoadPos.z - Player.z);
            if (curRoadPos.z - Player.z < roadSpawnInterval * RoadNeededAhead)
            {
                CreateRoad();
            }
        }
    }

    private Transform forwardTranstion;
    [SerializeField]
    [Tooltip("Used for spawning tunnels in at the right position(if it is set to 0, then tunnel will leave a gap)")]
    private float TunnelInterval;
    public void CreateRoad()
    {
        if (Player != null)
        {
            if (!IsThin)
            {
                Instantiate(roads[0], curRoadPos, Quaternion.identity);
                curRoadPos = new Vector3(curRoadPos.x, -11, curRoadPos.z + roadSpawnInterval);
                obsSpawner.SpawnObstacle(5);
                createdTransitionbackward = false;
            }
            else
            {
                if (!createdTransitionforward)
                {
                    Instantiate(roads[1], curRoadPos, Quaternion.identity);//Creates transition road forward
                    forwardTranstion = Instantiate(roads[2], Vector3.zero, Quaternion.identity);
                    curRoadPos.z -= TunnelInterval;
                     curRoadPos = new Vector3(curRoadPos.x, -4.5f, curRoadPos.z + roadSpawnInterval);
                    createdTransitionforward = true;
                }
                else if (createdTransitionbackward)
                {

                    forwardTranstion.position = new Vector3(curRoadPos.x, -11f, curRoadPos.z + TunnelInterval); ;
                    dat.Player.GetComponent<Rigidbody>().velocity = Vector3.zero;
                    dat.Player.position = new Vector3(TeleportedX, dat.Player.transform.position.y, curRoadPos.z + 20);
                    curRoadPos = new Vector3(curRoadPos.x, -11, curRoadPos.z + roadSpawnInterval);
                    createdTransitionbackward = false;
                    createdTransitionforward = false;
                    IsThin = false;
                }
                else
                {
                    Instantiate(roads[3], curRoadPos, Quaternion.identity);//Creates thin road
                    curRoadPos = new Vector3(curRoadPos.x, -4.5f, curRoadPos.z + roadSpawnInterval);
                }


            }
        }
    }

    public float TeleportedX;



}
