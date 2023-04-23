using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] private Text _scoreText; 

    private int _score = 0; 
    private int _addPoints = 5; 
    
    public void Start()
    {
        _scoreText.text = "Score: " + _score;
    }

    public void AddScore()
    {
        _score += _addPoints; 
        UpdateScoreText(); 
        MainManuFunction.score = _score;
    }

    public void UpdateScoreText()
    {
        _scoreText.text = "Score: " + _score;
    }
}
