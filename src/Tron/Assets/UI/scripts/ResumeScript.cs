using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ResumeScript : MonoBehaviour {

	public Transform pauseScreen;
	public Transform inGameUITest;

	//This function will be triggered when it is clicked (OnClick interface on UI.Button Inspector)
	public void Resume()
	{
		Debug.Log("Resume Success");

		inGameUITest.gameObject.SetActive(true);
		pauseScreen.gameObject.SetActive(false);
		Time.timeScale = 1.00f;
	}

}
