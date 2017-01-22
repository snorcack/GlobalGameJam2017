using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HamsterController : MonoBehaviour {

	public Animator wheelAnimator;
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
		runningSpeed = Mathf.Lerp(runningSpeed, inSpeed,Time.deltaTime);

		if (runningSpeed < 0)
			runningSpeed = 0;

		if (runningSpeed > 1)
			runningSpeed = 1;

		hamsterAnimator.SetFloat ("Blend", runningSpeed);
		wheelAnimator.SetFloat ("Blend", runningSpeed);
	}
}
