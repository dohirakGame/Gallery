using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenPhoto : MonoBehaviour
{
	private void OnMouseDown()
	{
		ShowSelectedPhoto.photoSpite = gameObject.GetComponent<Image>().sprite;
		FakeLoadingScreen.sceneName = "PhotoView";
		SceneManager.LoadScene("FakeLoadingScreen");
	}
}
