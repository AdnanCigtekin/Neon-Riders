using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour {


    [SerializeField]
    private EndlessRoadScript endlrd;
    [SerializeField]
    private Datas dT;
    [SerializeField]
    private Material[] mainMat;

    public int currentSkyboxTexture;
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Portal")
        {
            currentSkyboxTexture++;
            if (currentSkyboxTexture == mainMat.Length) currentSkyboxTexture = 0;

            

            //Skybox skybox = Camera.main.GetComponent<Skybox>();
            RenderSettings.skybox = mainMat[currentSkyboxTexture];


            GameObject[] portals = GameObject.FindGameObjectsWithTag("Portal");
            Vector3 thisPortal = other.gameObject.transform.position;
            endlrd.createdTransitionbackward = true;

            for (int i = 0; i < portals.Length; i++)
            {
                if(portals[i].transform.position.z < thisPortal.z)
                {
                    Debug.Log("this X:" + thisPortal.x + "\n" + "other X: " + portals[i].transform.position.x + "\n Diff: " + Mathf.Abs(thisPortal.x - portals[i].transform.position.x));
                    if(Mathf.Abs(thisPortal.x - portals[i].transform.position.x) < 0.5f)
                    {
                    
                        endlrd.TeleportedX = portals[i].transform.position.x;
                        endlrd.CreateRoad();
                        Debug.Log("transported");
                        Destroy(dT.curEnemy.gameObject);
                        return;
                    }
                }
            }
        }
    }
}
