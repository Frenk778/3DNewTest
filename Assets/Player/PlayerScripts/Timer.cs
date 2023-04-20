using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{          
    public Text timerText;
    private float startTime;
    private bool isTimerRunning = true;
    

    void Start()
    {
        startTime = Time.time;        
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");
              
        timerText.text = "Timer: " + minutes + ":" + seconds;
    }

    public void StopTimer()
    {
        isTimerRunning = false; 
        MainManuFunction.time = Time.time - startTime;
    }
}
