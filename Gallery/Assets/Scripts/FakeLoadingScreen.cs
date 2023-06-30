using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FakeLoadingScreen : MonoBehaviour
{
	[SerializeField] private Image progressBar;
	[SerializeField] private TextMeshProUGUI percentBarText;

	private float _loadTime = 3f;
	private float _timer = 0f;
	private float _percent = 0f;

	public static string sceneName;

	private void Start()
	{
		if (sceneName == "Gallery") StartCoroutine(LoadScreen(sceneName));
		else if (sceneName == "PhotoView") StartCoroutine(LoadScreen(sceneName));
	}

	private void Update()
	{
		if (_timer < _loadTime)
		{
			_timer += 1f * Time.deltaTime;
			progressBar.fillAmount = _timer / _loadTime;
			_percent = (int)(progressBar.fillAmount * 100);

			percentBarText.text = $"Loading: {_percent}%";
		}
	}

	private IEnumerator LoadScreen(string name)
	{
		yield return new WaitForSeconds(_loadTime);
		SceneManager.LoadScene(name);
	}
}
