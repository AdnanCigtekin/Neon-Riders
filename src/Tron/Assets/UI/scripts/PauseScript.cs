using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PauseScript : MonoBehaviour {

	public Transform pauseScreen;
	public Transform inGameUITest;

	//This function will be triggered when it is clicked (OnClick interface on UI.Button Inspector)
	public void Pause()
	{
		Debug.Log("Pause Success");

		pauseScreen.gameObject.SetActive(true);
		inGameUITest.gameObject.SetActive(false);
		Time.timeScale = 0.00f;
	}



}
