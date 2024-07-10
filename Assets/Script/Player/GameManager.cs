using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject canvasGO;
    public Button buttonGO;
    public Button buttonRematch;

    void Start()
    {
        canvasGO.SetActive(false);
    }

    public void OnclickQUit()
    {
        if(buttonGO.interactable)
        {
            Application.Quit();
        }
    }

    public void OnclickRematch()
    {
        if(buttonGO.interactable)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void GameOverScene()
    {
        canvasGO.SetActive(true);
    }
}
