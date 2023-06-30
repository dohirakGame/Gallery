using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
	private Color randomColor;
	private void OnMouseDown()
	{
		SetRandomColor();
		Change();
	}

	private void SetRandomColor()
	{
		randomColor = new Color(Random.value, Random.value, Random.value);
	}

	private void Change()
	{
		gameObject.GetComponent<Renderer>().material.color = randomColor;
	}
}
