using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vectrosity;


public class Wave : MonoBehaviour {



	public Material lineMat;
	public Texture2D lineTexture;
	public float wavePosX;
	public float wavePosY;

	public float Amplitude {
		get {
			return amplitude;
		}
		set {
			amplitude = value;
		}
	}

	float amplitude = 1;
	float frequency = 1 ;

	public float Frequency {
		get {
			return frequency;
		}
		set {
			frequency = value;
		}
	}

	int segments = 300;
	VectorLine waveLine ;
	int curvePointCount = 15;
	Vector3[] curvePoints = new Vector3[15];

	// Use this for initialization
	void Start () {
		waveLine  = new VectorLine ("Spline",new List<Vector3>(segments+1),null,5.0f,LineType.Continuous);

		waveLine.material = lineMat;
		waveLine.texture = lineTexture;
		waveLine.rectTransform.position = new Vector3( wavePosX,wavePosY,0);


		UpdateWave ();
	}


	
	// Update is called once per frame
	void Update () {

		if (GameConstants.isPaused)
			return;
		
		AnimateWave ();
		
	}

	public void UpdateWave()
	{
		int flipper = 1;

		for (int i = 0; i < curvePointCount; i++) {
			curvePoints [i] = new Vector3 (i*frequency,amplitude*flipper,0);
			Debug.Log (curvePoints[i].y);
			flipper *= -1;
		}
		DrawWave ();
	}



	public void DrawWave ()
	{
		waveLine.MakeSpline (curvePoints, segments, false);
		waveLine.Draw3D ();
	}

	void AnimateWave()
	{
		for (int i = 0; i< curvePointCount; i++) {
		
			curvePoints [i].x -= 0.1f;


		}

		if (curvePoints [0].x < (-2 * frequency)) {

			UpdateWave ();

		}

		DrawWave ();
	}

}
