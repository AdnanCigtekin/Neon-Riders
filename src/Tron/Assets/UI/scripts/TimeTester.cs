using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeTester : MonoBehaviour {

	//CheckFunc if Pause/Resume works
	void Update()
	{
		transform.Translate(Vector3.up * Time.deltaTime, Space.World);
	}
}
