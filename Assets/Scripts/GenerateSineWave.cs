using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;

public class GenerateSineWave : MonoBehaviour {

	int segments = 250;
	Vector2[] curvePoints = new Vector2[9-1];
	int amplitude = 100;
	int flipper = -1;

	VectorLine line;
	// Use this for initialization
	void Start () {
		
		for (int i = 0; i < 8; i++) {
			curvePoints [i] = new Vector2 (i*100,amplitude*flipper+100);
			Debug.Log (curvePoints[i].y);
			flipper *= -1;
		}

		line = new VectorLine ("Spline",new List<Vector2>(segments+1),null,2.0f,LineType.Continuous);

		CreateLine ();


	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyUp (KeyCode.Space)) {
			ChangeValues ();
		
		}
	}

	void ChangeValues ()
	{
		for (int i = 0; i < 8; i++) {
			curvePoints [i] = new Vector2 (i*50,amplitude*flipper+100);
			Debug.Log (curvePoints[i].y);
			flipper *= -1;
		}
		CreateLine ();

	}

	void CreateLine ()
	{
		
		line.MakeSpline (curvePoints,segments,false);
		line.Draw ();
	}
}
