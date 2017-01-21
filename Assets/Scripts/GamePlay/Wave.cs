﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;


public class Wave : MonoBehaviour {



	public Material lineMat;
	public Texture2D lineTexture;
	public float wavePosX;
	public float wavePosY;
	public bool isInteractive;

	Vector3 waveIncrement = new Vector3 (0.1f,0,0);

	public float Amplitude {
		get {
			return amplitude;
		}
		set {
			amplitude = value;
		}
	}

	float amplitude = 0.7f;
	float frequency = 1 ;
	float waveSpeed = 0.1f;
	float targetAmplitude = 1;
	float amplitudeDelta = 0.1f;

	float targetFrequency =1 ;
	float frequencyDelta = 0.1f;

	public float Frequency {
		get {
			return frequency;
		}
		set {
			frequency = value;
		}
	}

	int segments = 500;
	VectorLine waveLine ;
	int curvePointCount = 50;

	List<Vector3> wavePoints = new List<Vector3> ();

	// Use this for initialization
	void Start () {
		waveLine  = new VectorLine ("Spline",new List<Vector3>(segments+1),null,10.0f,LineType.Continuous,Joins.Weld);

		waveLine.material = lineMat;
		waveLine.texture = lineTexture;
		waveLine.rectTransform.position = new Vector3( wavePosX,wavePosY,0);

		UpdateWave ();
	}


	
	// Update is called once per frame
	void Update () {

		if (GameConstants.isPaused)
			return;
		SetColor (1);
		AnimateWave ();

		if (!isInteractive)
			return;

		if (Input.GetKey (KeyCode.RightArrow)) {
			targetFrequency += 0.01f;
			if (targetFrequency > 3)
				targetFrequency = 3;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			targetFrequency -= 0.01f;
			if (targetFrequency < 0.25f)
				targetFrequency = 0.25f;
		}

		if (Input.GetKeyUp (KeyCode.Tab)) {
			Debug.Log (frequency);	
			}
	}

	public void UpdateWave()
	{
		int flipper = 1;

		wavePoints.Clear ();

		for (int i = 0; i < curvePointCount; i++) {
			wavePoints.Add ( new Vector3 (i*frequency,amplitude*flipper,0));
			flipper *= -1;
		}
		DrawWave ();

	}



	public void DrawWave ()
	{
		waveLine.MakeSpline (wavePoints.ToArray(), segments, false);
		waveLine.Draw3D ();
	}

	public void SetColor (float targetFreq)
	{
		if (!isInteractive) {
			return;
		}

		float diff = Mathf.Abs (targetFreq - frequency);
		float multiplier = 0;



		if (diff > 0.5f) {
			multiplier = 1;
		} else {
			multiplier = diff / 0.5f;
		} 

		if (diff < 0.1f)
			multiplier = 0;
		
		//Debug.Log (multiplier + "" + frequency);
		lineMat.SetFloat ("_Hue",multiplier * 0.67f);
		waveLine.material = lineMat;

	}

	void AnimateWave()
	{
		
		for (int i = 0; i< curvePointCount; i++) {
		

			wavePoints [i] -= waveIncrement;

		}

		frequencyDelta = Mathf.Abs (targetFrequency - frequency) / 5;
		if (frequencyDelta < 0.1f)
			frequencyDelta = 0.1f;

		float currentSign = Mathf.Sign (wavePoints[wavePoints.Count-1].y);
		float currentFrequency = wavePoints [wavePoints.Count - 1].x;

		if (wavePoints [0].x < ( -2*frequency) + waveSpeed) {
			wavePoints.RemoveAt (0);

			if (Mathf.Abs (frequency - targetFrequency) < 0.11f) {
				frequency = targetFrequency;
				}

			if (frequency < targetFrequency) {
				frequency += frequencyDelta;
			} else if (frequency > frequencyDelta) {
				frequency -= frequencyDelta;
			}

			if (currentFrequency <9f || curvePointCount < 15)
			{
				while (currentFrequency + frequency < 12) {
				
					wavePoints.Add (new Vector3 (currentFrequency + frequency, amplitude * currentSign * -1, 0));
					currentFrequency += frequency;
					currentSign *= -1;
				}
			}

			curvePointCount = wavePoints.Count;
		}

		DrawWave ();
	}



}
