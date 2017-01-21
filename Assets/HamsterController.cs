using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour {

	Animator hamsterAnimator;
	float runningSpeed = 0;

	// Use this for initialization
	void Start () {
		hamsterAnimator = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void SetHamsterSpeed (float inSpeed)
	{
		runningSpeed += inSpeed;

		hamsterAnimator.SetFloat ("Blend", runningSpeed);
	}
}
