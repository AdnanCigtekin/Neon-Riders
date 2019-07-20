using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour {
	public bool gameStarted;

	// Use this for initialization
	void Start () {
		gameStarted = false;
	}
	
	public void SetBool()
	{
		gameStarted = true;
	}
}
