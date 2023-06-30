using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class PhotoLoader : MonoBehaviour
{
    [SerializeField] private int photoCount;
	[SerializeField] private Image photoSpacePrefab;
	[SerializeField] private GridLayoutGroup parentForImage;
	[SerializeField] private ScrollRect scrollRect;

	[SerializeField] private List<Image> images;

	private bool _canLoad;

	private void Start()
	{
		_canLoad = false;
		InitializePhotoSpace();
		StartCoroutine(LoadImages());
	}

	private void Update()
	{
		if (_canLoad)
		{
			for (int i = 0; i < photoCount; i++)
			{
				if (!images[i].GetComponent<LoadData>().isLoaded)
				{
					if (IsVisible(images[i].rectTransform, Camera.main))
					{
						images[i].GetComponent<LoadData>().isLoaded = true;
						Debug.Log($"Загружаю {i}");
						StartCoroutine(LoadImageFromURL(i));
					}
					else return;
				}
			}
		}
	}

	private void InitializePhotoSpace()
	{
		for (int i = 0; i < photoCount; i++)
		{
			Image photo = Instantiate(photoSpacePrefab, parentForImage.transform);
			images.Add(photo);
			images[i].GetComponent<LoadData>().photoIndex = i;
		}

		float elementHeight = 300;

		float gridHeight = parentForImage.padding.top + (elementHeight + parentForImage.spacing.y) * photoCount;
		Vector2 newPosition = new Vector2(transform.localPosition.x, -gridHeight);
		parentForImage.transform.localPosition = newPosition;
	}

	private IEnumerator LoadImages()
	{
		yield return new WaitForSeconds(1f);
		Debug.Log("Загрузка начата");

		for (int i = 0; i < photoCount; i++)
		{
			if (IsVisible(images[i].rectTransform, Camera.main))
			{
				Debug.Log($"Видно {i+1}");
				images[i].GetComponent<LoadData>().isLoaded = true;
				yield return StartCoroutine(LoadImageFromURL(i));
			}
			else
			{
				Debug.Log($"Не видно {i+1}");
				yield return null;
			}
		}
		_canLoad = true;
	}
	private bool IsVisible(RectTransform target, Camera camera)
	{
		Vector3[] corners = new Vector3[4];
		target.GetWorldCorners(corners);
		int visibleCorners = 0;
		Rect rect = new Rect(0, 0, Screen.width, Screen.height);
		foreach (Vector3 corner in corners)
		{
			Vector3 screenCorner = camera.WorldToScreenPoint(corner);
			if (rect.Contains(screenCorner))
			{
				visibleCorners++;
			}
		}
		return visibleCorners == 4;
	}

	private IEnumerator LoadImageFromURL(int index)
	{
		UnityWebRequest request = UnityWebRequestTexture.GetTexture($"http://data.ikppbb.com/test-task-unity-data/pics/{index + 1}.jpg");
		yield return request.SendWebRequest();

		if (request.result == UnityWebRequest.Result.Success)
		{
			Texture2D texture = ((DownloadHandlerTexture)request.downloadHandler).texture;
			Sprite sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));

			images[index].sprite = sprite;
			
		}
		else
		{
			Debug.LogError("Failed to load image from " + $"http://data.ikppbb.com/test-task-unity-data/pics/{index + 1}.jpg");
		}
	}
}
