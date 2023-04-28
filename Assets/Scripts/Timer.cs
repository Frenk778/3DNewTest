using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text _timerText;

    private float _startTime;    
    private const int _secondsInMinute = 60;
    private const string _twoDigitFormat = "00";

    public void Start()
    {
        _startTime = Time.time;       
    }

    private void Update()
    {
        float elapsedTime = Time.time - _startTime;

        string minutes = ((int)elapsedTime / _secondsInMinute).ToString(_twoDigitFormat);
        string seconds = (elapsedTime % _secondsInMinute).ToString(_twoDigitFormat);

        _timerText.text = "Timer: " + minutes + ":" + seconds;
    }    
}