using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowSelectedPhoto : MonoBehaviour
{
	public static Sprite photoSpite;

	[SerializeField] private Image photoField;
	private void Start()
	{
		photoField.sprite = photoSpite;
	}
}
