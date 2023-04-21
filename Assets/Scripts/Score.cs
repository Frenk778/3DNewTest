using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]private Text scoreText; 
    private int score = 0; 
    
    public void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += 5; 
        UpdateScoreText(); 
        MainManuFunction.score = score;
    }

    public void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
