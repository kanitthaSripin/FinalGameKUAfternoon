using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaygroundSceneManager : MonoBehaviour
{   
    public Text uiTextBall;
    public Text uiTextTime;
    public Text t;
    public float n;
    public float countDown = 5;

    public void GoToHome()
    {
       SceneManager.LoadScene("Home"); 
    }

    public void SetTextBall(int amount)
    {
        uiTextBall.text = amount.ToString();
    }

    public void SetTextTime(int amount)
    {
        uiTextTime.text =  amount.ToString();
    }

    void Update()
    {
       n -= Time.deltaTime;
       t.text = Mathf.Round(n).ToString();
       if(n<= 0)
       {
        t.text = "หมดเวลา";
       }
       
    } 
    void FixeUpdate()
    {
       n = Time.deltaTime + countDown;
       t.text = Mathf.Round(n).ToString();
       if(n<= 0)
       {
        t.text = "หมดเวลา";
       }
       
    } 
}

