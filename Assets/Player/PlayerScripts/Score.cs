using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText; 
    private int score = 0; 
    
    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += 5; 
        UpdateScoreText(); 
        MainManuFunction.score = score;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
