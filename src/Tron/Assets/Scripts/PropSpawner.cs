using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PropSpawner : MonoBehaviour {

    [SerializeField]
    private Datas dT;
    [SerializeField]
    private Transform[] Props;
    private Transform Player;
    [SerializeField]
    private Vector3 SpawnerPivot;
    [SerializeField]
    private float SpawnerWidth;
    [SerializeField]
    private float BuildingInterval;
    [SerializeField]
    private Color curColor;
    [SerializeField]
    private float distToCreate;
    private float BuildingHeight;
    private void Start()
    {
        BuildingHeight = Props[0].localScale.y;
        Player = dT.Player;
    }

    private void Update()
    {
        if (Player != null)
        {
            if (Player.position.z + distToCreate > SpawnerPivot.z)
            {
                CreateBuilding();
            }
        }
    }

    private void CreateBuilding()
    {
        
        changeRGB();
        float randWidth;
        changeSizeOfBuildings();
        #region Spawning the building in the right
            int randVal = Random.Range(0, Props.Length);
            randWidth = Random.Range(0, 20);
        for (int i = 0; i < 3; i++)
        {
            randWidth += 20;
            Vector3 rightBuildingPos = new Vector3(SpawnerPivot.x + SpawnerWidth + randWidth, SpawnerPivot.y, SpawnerPivot.z + BuildingInterval);
            Transform a = Instantiate(Props[randVal], rightBuildingPos, Quaternion.identity);
            a.GetComponent<Renderer>().material.SetColor("_MainTint", curColor);
        }
        #endregion

        #region Spawning the building in the right
            randVal = Random.Range(0, Props.Length);
            randWidth = Random.Range(0, 20);
        for (int i = 0; i < 3; i++)
        {
            randWidth += 20;
            Vector3 leftBuildingPos = new Vector3(SpawnerPivot.x - SpawnerWidth - randWidth, SpawnerPivot.y, SpawnerPivot.z + BuildingInterval);
            Transform b = Instantiate(Props[randVal], leftBuildingPos, Quaternion.identity);
            b.GetComponent<Renderer>().material.SetColor("_MainTint", curColor);
        }
        #endregion

        SpawnerPivot = new Vector3(SpawnerPivot.x, SpawnerPivot.y, SpawnerPivot.z + BuildingInterval);


    }

    [SerializeField]
    private PortalHandler pH;
    private void changeSizeOfBuildings()
    {
        for(int i= 0; i< Props.Length; i++)
        {
            if (pH.currentSkyboxTexture == 0)
                Props[i].localScale = new Vector3(Props[i].localScale.x, BuildingHeight / 2, Props[i].localScale.z);
            else
                Props[i].localScale = new Vector3(Props[i].localScale.x, BuildingHeight * 2, Props[i].localScale.z);

        }

    }


    private float curR = 255;
    private float curG = 0;
    private float curB = 0;
    [SerializeField]
    private int ColorChangeAmount;
    private int curState;
    /**
     *  0-> R= 255   G++  B=0
     *  1-> R--      G=255  B=0
     *  2-> R=0      G==    B++
     *  3-> R = 0    G--    B = 255
     *  4-> R++      G = 0  B = 255
     *  5-> R=255    G=0   B--
     * /
    */

    private void changeRGB()
    {
        switch (curState)
        {

            case (0):
                curG += ColorChangeAmount;

                if(curG >= 255)
                {
                    curG = 255;
                    curState = 1;
                }
                break;

            case (1):
                curR -= ColorChangeAmount;
                if (curR <= 0)
                {
                    curR = 0;
                    curState = 2;
                }
                break;

            case (2):
                curB += ColorChangeAmount;
                if (curB >= 255)
                {
                    curB = 255;
                    curState = 3;
                }
                break;

            case (3):
                curG -= ColorChangeAmount;
                if (curG <= 0)
                {
                    curG = 0;
                    curState = 4;
                }
                break;

            case (4):
                curR += ColorChangeAmount;
                if (curR >= 255)
                {
                    curR = 255;
                    curState = 5;
                }
                break;

            case (5):
                curB -= ColorChangeAmount;
                if (curB <= 0)
                {
                    curB = 0;
                    curState = 0;
                }
                break;
            default:
                Debug.LogError("Failed to change the color!");
                break;
        }
        curR /= 255;
        curG /= 255;
        curB /= 255;
        Color newColor = new Color(curR,curG,curB,255);
        curColor = newColor;
        curR *= 255;
        curG *= 255;
        curB *= 255;
    }

}
