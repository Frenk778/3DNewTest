using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuFunction : MonoBehaviour
{    
    internal static float time;
    internal static int score;

    void Start()
    {
        
    }


    void Update()
    {
        
    }
    
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

}
