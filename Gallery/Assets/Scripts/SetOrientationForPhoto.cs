using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetOrientationForPhoto : MonoBehaviour
{
	private void Start()
	{
		DontDestroyOnLoad(gameObject);
		string sceneName = SceneManager.GetActiveScene().name;
		if (sceneName == "PhotoView") Screen.orientation = ScreenOrientation.AutoRotation;
		else Screen.orientation = ScreenOrientation.Portrait;
	}
}
