using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{  
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }    
}