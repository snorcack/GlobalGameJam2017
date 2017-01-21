using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointerListener : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
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

		// DO SOMETHING HERE
	}
}