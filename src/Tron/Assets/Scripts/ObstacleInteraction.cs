using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleInteraction : MonoBehaviour {

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GetComponent<VehiclePhysics>().DestroyMe();
        }
        if (collision.gameObject.tag == "EnemyFlare")
        {
            GetComponent<VehiclePhysics>().DestroyMe();
        }
    }
    [SerializeField]
    private Datas dT;
    private void OnDestroy()
    {
        dT.Player = null;
    }

}
