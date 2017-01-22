using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoolDownController : MonoBehaviour {

	Slider coolDownSlider ;
	float coolDelta;
	bool isNotMatching = false;
	float currentSliderValue ;
	float timeToCool;

	// Use this for initialization
	void Start () {
		coolDownSlider = GetComponent<Slider> ();
		//coolDownSlider.value = 0.5f;
		currentSliderValue = 6;
		coolDelta = 0.01f;
		timeToCool = 6;
	}

	void OnEnable ()
	{
		Events.instance.AddListener <FrequencyChangedEvent>(FrequencyChangeHandler);
		Events.instance.AddListener <FrequencyMatchedEvent> (FrequencyMatchHandler);
	}

	void OnDisable ()
	{
		Events.instance.RemoveListener <FrequencyChangedEvent>(FrequencyChangeHandler);
		Events.instance.RemoveListener <FrequencyMatchedEvent> (FrequencyMatchHandler);
	}

	void FrequencyMatchHandler (GameEvent e)
	{
		isNotMatching = false;
	}

	void SetMatchingTrue ()
	{
		isNotMatching = true;
	}

	void FrequencyChangeHandler (GameEvent e)
	{
		SetMatchingTrue ();
		//Invoke ("SetMatchingTrue",1.0f);
	}

	// Update is called once per frame
	void Update () {
		if (isNotMatching) {
			currentSliderValue -= Time.deltaTime;
		} else {
			currentSliderValue += Time.deltaTime;
		}

		if (currentSliderValue > timeToCool)
			currentSliderValue = timeToCool;

		//Debug.Log (currentSliderValue);
		coolDownSlider.value = currentSliderValue / timeToCool;

		if (currentSliderValue < 0) {
			currentSliderValue = timeToCool;
			//Debug.Log ("Life Loss Event !!");
			Events.instance.Raise  (new LifeLossEvent ());

		}
	}
}
