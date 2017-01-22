// This script will remove the hearts. 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using UnityEngine.SceneManagement;

public class LifeManager : MonoBehaviour 
{
	#region Public Varaibles

	public RectTransform[] _lifeArray = new RectTransform[3];

	#endregion

	#region Private Variables

	private List<Image>	_lifeImageList;

	#endregion

	#region Main Functions
	// Use this for initialization
	void Awake () 
	{
		_lifeImageList = new List<Image>();

		if( _lifeArray.Length > 0 )
		{
			for (int i = 0; i < _lifeArray.Length; i++) 
			{
				var image = _lifeArray [i].GetComponent <Image> ();

				if (image != null) 
				{
					_lifeImageList.Add (image);				
				}
			}
		}
	
		for (int j = 0; j < _lifeImageList.Count; j++)
		{
			Debug.Log (_lifeImageList[j].sprite.name);
		}
	}

	void OnEnable ()
	{
		Events.instance.AddListener <LifeLossEvent> (LifeLossHandler);
	}


	void OnDisable ()
	{
		Events.instance.RemoveListener <LifeLossEvent> (LifeLossHandler);
	}

	void LifeLossHandler (GameEvent e)
	{
		ReduceHealth ();
	}


	// This function will reduce the life starting from back in the list.
	public void ReduceHealth()
	{
		if (_lifeImageList.Count > 0) {
			_lifeImageList [_lifeImageList.Count - 1].enabled = false;
			_lifeImageList.RemoveAt (_lifeImageList.Count - 1);
		} else {
			SceneManager.LoadScene ("GameOverScene", LoadSceneMode.Single);		
		}
	}

	#endregion

}
