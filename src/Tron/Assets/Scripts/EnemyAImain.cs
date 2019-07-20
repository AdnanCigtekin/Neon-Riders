using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAImain : MonoBehaviour {

    private Datas dT;
    private Transform Player;
    private VehiclePhysics vP;
    private EndlessRoadScript endlrd;
    private int State;

    [SerializeField]
    private float WidthOfTheThinnerRoad;
    /*
     0->Behind the player +
     1->Passing the player
     2->Ahead of the Player

         */
    private float PlayerAheadDistance = 10f;
    private void Start()
    {
        dT = GameObject.Find("GlobalDataHolder").GetComponent<Datas>();
        Player = dT.Player;
        vP = GetComponent<VehiclePhysics>();
        vP.setForwardSpeed(normalForwardSpeed);
        endlrd = GameObject.Find("WorldCreator").GetComponent<EndlessRoadScript>();
    }

    private void Update()
    {
        if (Player != null)
        {
            if (State == 0) BehindThePlayer();
            if (State == 1) PassingThePlayer();
            if (State == 2) PassedThePlayer();
        }

    }


    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            Destroy(collision.gameObject);
        }
    }

    public int getState()
    {
        return State;
    }


    private float normalForwardSpeed = 80;
    private float TurboForwardSpeed = 160;


    private void PassedThePlayer()
    {

       if (dummycurTimer < 0 && !endlrd.IsThin)
        {
            Debug.Log("ehehehe");
            endlrd.IsThin = true;
            dummycurTimer = 10;
        }
        dummycurTimer -= Time.deltaTime;
        if (dummycurTimer < 0)
        {
            
            if (transform.position.x > Player.position.x)
            {
                if (transform.position.x <= -WidthOfTheThinnerRoad ) vP.setSideWaysSpeed(0);
                else vP.setSideWaysSpeed(-3);
            }

            if (transform.position.x < Player.position.x)
            {
                if (transform.position.x >= WidthOfTheThinnerRoad) vP.setSideWaysSpeed(0);
                else vP.setSideWaysSpeed(3);
            }

            if (transform.position.x > WidthOfTheThinnerRoad ) vP.setSideWaysSpeed(-3);
            if (transform.position.x < -WidthOfTheThinnerRoad ) vP.setSideWaysSpeed(3);

            if (Player.position.z > transform.position.z)
                State = 0;
        }
    }






    private void PassingThePlayer()
    {
        if (flag)
        {
            vP.setSideWaysSpeed(0);
            vP.setForwardSpeed(TurboForwardSpeed);
            flag = false;
        }
        if (Player != null)
        {


            if (transform.position.z - PlayerAheadDistance > Player.position.z)
            {
                vP.setForwardSpeed(normalForwardSpeed);
                State = 2;
                flag = true;
            }
        }

    }




    private float dummyTimer;
    private float dummycurTimer;
    private bool flag = true;

    private void BehindThePlayer()
    {
        bool GoingRight = false;

        if (flag)
        {
            setTimer(5);
            flag = false;
        }

        if(transform.position.x < Player.position.x)
        {
            if (transform.position.x < -WidthOfTheThinnerRoad / 2) GoingRight = true;
            else
            {
                GoingRight = false;
            }
        }

        if (transform.position.x >= Player.position.x)
        {
            if (transform.position.x > WidthOfTheThinnerRoad / 2) GoingRight = false;
            else
            {
                GoingRight = true;
            }

        }

        if (GoingRight) vP.setSideWaysSpeed(5);
        else vP.setSideWaysSpeed(-5);

        if(dummycurTimer < 0)
        {
            Debug.Log("fdfs");
            State = 1;
            flag = true;
        }
        dummycurTimer -= Time.deltaTime;

    }

    private void setTimer(float newTime)
    {
        dummyTimer = newTime;
        dummycurTimer = newTime;
    }


    

}
