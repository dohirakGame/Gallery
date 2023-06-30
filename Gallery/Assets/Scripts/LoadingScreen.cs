using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScreen : MonoBehaviour
{
	[SerializeField] private Image progressBar;
	[SerializeField] private TextMeshProUGUI progressText;

	private void Awake()
	{
		StartCoroutine(LoadAsyncOperation());
	}

	private IEnumerator LoadAsyncOperation()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync("Gallery");
		operation.allowSceneActivation = false;

		float timer = 0.0f;
		while (!operation.isDone)
		{
			timer += Time.deltaTime;
			float progress = Mathf.Clamp01(timer / 10f);

			progressBar.fillAmount = progress;
			progressText.text = progress * 100f + "%";

			if (progress >= 1 && operation.progress >= 0.9f)
			{
				operation.allowSceneActivation = true;
			}

			yield return null;
		}
	}
}
