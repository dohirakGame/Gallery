using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    public void OpenGallery()
    {
        FakeLoadingScreen.sceneName = "Gallery";
        SceneManager.LoadScene("FakeLoadingScreen");
    }

    public void ExitFromPhotoView()
    {
        FakeLoadingScreen.sceneName = "Gallery";
        SceneManager.LoadScene("FakeLoadingScreen");
    }
}
