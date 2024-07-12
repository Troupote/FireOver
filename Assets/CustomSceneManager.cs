using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CustomSceneManager : MonoBehaviour
{
    public Button switchScenB;
    public int sceneName1;

    public void OnClickButtonScene()
    {
        if (switchScenB.interactable)
        {
            LoadScene3(sceneName1);
        }
    }

    public void LoadScene3(int sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName); // Use Unity's SceneManager explicitly
    }

}
