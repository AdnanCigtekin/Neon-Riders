using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltHandling : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    [SerializeField]
    private VehiclePhysics vP;
	void Update () {
        if (Input.GetKey("d"))
            vP.setSideWaysSpeed(10);
        if (Input.GetKey("a"))
            vP.setSideWaysSpeed(-10);
        if(Input.GetKeyUp("d") || Input.GetKeyUp("a"))
            vP.setSideWaysSpeed(0);
        //vP.setSideWaysSpeed(Input.acceleration.x);

    }
}
