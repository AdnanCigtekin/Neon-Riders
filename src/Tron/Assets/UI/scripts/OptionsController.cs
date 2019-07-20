using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsController : MonoBehaviour {
	//This function is used to store and manage user options data.

	bool audioCheck;
	[SerializeField]
	GameObject audioController;


	// Use this for initialization
	void Start () {
		audioCheck = true;
	}

	// Update is called once per frame
	void Update () {
		
	}


	public void AudioOnOff()
	{
		if (audioCheck == true)
		{
			audioCheck = false;
			audioController.SetActive(false);
		}
		else
		{
			audioCheck = true;
			audioController.SetActive(true);
		}
	}
}
