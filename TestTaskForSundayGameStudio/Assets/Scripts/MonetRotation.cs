using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonetRotation : MonoBehaviour
{
	[SerializeField] private float rotationSpeed;
	private void Start()
	{
		gameObject.transform.localEulerAngles = new Vector3(90,0,0) ;
	}
	private void Update()
	{
		Vector3 rotationDirection = new Vector3(0f, rotationSpeed, 0f) * Time.deltaTime;
		gameObject.transform.localEulerAngles += rotationDirection;
	}
}
