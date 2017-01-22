using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	public Wave targetWave;
	public Wave currentWave;

	public HamsterController hamster;

	float powerIncrement;
	float randomInterval = 10f;
	float requiredFrequency = 1;

	// Use this for initialization
	void Start () {
		Invoke ("ChangeTargetFrequency", randomInterval);
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

	void ChangeTargetFrequency ()
	{
		requiredFrequency = Random.Range (0.25f, 2.75f);
		targetWave.SetTargetFrequencyImplicit (requiredFrequency);
		currentWave.SetRequiredFrequency (requiredFrequency);
		Invoke ("ChangeTargetFrequency", randomInterval);
	}
		
	public void SetPower (int inPower)
	{
		float frequencyDelta = 0.01f;
		//float hamsterDelta = -0.02f;
		float hamsterSpeed;

		if (currentWave.Frequency < 0.7) {
			hamsterSpeed = 1;
		} else if (currentWave.Frequency > 2) {
			hamsterSpeed = 0;
		} else {
			hamsterSpeed = 0.5f;
		}

		currentWave.ModifyCurrentFrequency (frequencyDelta * inPower);
		hamster.SetHamsterSpeed (hamsterSpeed);
	}
}
