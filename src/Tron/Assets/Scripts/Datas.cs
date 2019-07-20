using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Datas : MonoBehaviour
{
	public Transform Player;
    public Transform curEnemy;

    private EndlessRoadScript endlrd;

    private float deathTimer = 3f;

    private void Start()
    {
        endlrd = GameObject.Find("WorldCreator").GetComponent<EndlessRoadScript>();
    }
    private void Update()
    {
        if(curEnemy != null && Player != null)
        {
            EnemyAImain enemyAI = curEnemy.GetComponent<EnemyAImain>();
            if(enemyAI.getState() == 2 && curEnemy.position.z < Player.transform.position.z)
            {
                endlrd.createdTransitionbackward = true;
            }
        }

        if(Player == null)
        {
            deathTimer -= Time.deltaTime;
            if(deathTimer < 0)
             SceneManager.LoadScene(0);
        }
    }

}
