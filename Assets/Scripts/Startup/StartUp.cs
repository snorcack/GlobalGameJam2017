using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour 
{


	// Loading the main Scene.
	public void LoadMainScene () 
	{
		SceneManager.LoadScene ("SineWaveScene", LoadSceneMode.Single);			
	}	
}
