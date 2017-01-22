using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
	public GameController controllerRef;
	public int sign;
	bool _pressed = false;
	public void OnPointerDown(PointerEventData eventData)
	{
		_pressed = true;
	}

	public void OnPointerUp(PointerEventData eventData)
	{
		_pressed = false;
	}

	void Update()
	{
		if (!_pressed)
			return;

		controllerRef.SetPower (sign * 1);
		// DO SOMETHING HERE
	}
}