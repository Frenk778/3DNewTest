using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{    
    //[SerializeField]private SaveLoad _saveLoad;
    public Text timerText;
    private float startTime;
    private bool isTimerRunning = true; // переменна€, указывающий, что таймер запущен
    

    void Start()
    {
        startTime = Time.time;
        //startTime = _saveLoad.ReadTimer();
        timerText = GameObject.Find("TimerText").GetComponent<Text>();
    }

    void Update()
    {
        float elapsedTime = Time.time - startTime;

        // ѕреобразуем врем€ в формат минут:секунды
        string minutes = ((int)elapsedTime / 60).ToString("00");
        string seconds = (elapsedTime % 60).ToString("00");

        // ќбновл€ем текст в UI с отображением времени        
        timerText.text = "Timer: " + minutes + ":" + seconds;
    }

    public void StopTimer()
    {
        isTimerRunning = false; // останавливаем таймер
        MainManuFunction.time = Time.time - startTime;
    }
}
