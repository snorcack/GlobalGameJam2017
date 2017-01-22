using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartUp : MonoBehaviour 
{
	public GameObject buttonRef;
	public GameObject panelRef;
	public GameObject tutorialButton ;

	public void ShowTutorial()
	{
		panelRef.SetActive (false);
		buttonRef.SetActive (false);
		tutorialButton.SetActive (true);
		
		}

	// Loading the main Scene.
	public void LoadMainScene () 
	{
		SceneManager.LoadScene ("SineWaveScene", LoadSceneMode.Single);			
	}	
}
