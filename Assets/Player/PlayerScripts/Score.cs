using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText; // ссылка на текстовое поле    
    private int score = 0; // текущее количество очков

    void Start()
    {
        scoreText.text = "Score: " + score;
    }

    public void AddScore()
    {
        score += 5; // увеличиваем количество очков на 5
        UpdateScoreText(); // обновляем текстовое поле
        MainManuFunction.score = score;
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
