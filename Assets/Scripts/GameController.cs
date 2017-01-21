using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Wave targetWave;
	public Wave currentWave;

	public HamsterController hamster;

	float powerIncrement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			SetPower (-1);
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			SetPower (1);
		}

	}


	public void SetPower (int inPower)
	{
		float frequencyDelta = 0.01f;
		float hamsterDelta = -0.01f;

		currentWave.SetTargetFrequency (frequencyDelta * inPower);
		hamster.SetHamsterSpeed (hamsterDelta * inPower);
	}
}
