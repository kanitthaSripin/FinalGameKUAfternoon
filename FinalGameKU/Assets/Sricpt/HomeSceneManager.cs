using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeSceneManager : MonoBehaviour
{
    public void GoToPlayground()
    {
        PlayerPrefs.SetInt("BallCount",0);
        SceneManager.LoadScene("Playground");
    }
    public void ContinuePlay()
    {
        if(PlayerPrefs.HasKey("PrevScene"))
        {
            string prevSceneName = PlayerPrefs.GetString("PrevScene");
            SceneManager.LoadScene(prevSceneName);
        }
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
