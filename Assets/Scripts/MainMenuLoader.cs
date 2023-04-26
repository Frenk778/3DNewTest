using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuLoader : MonoBehaviour
{        
    private CursorLockMode _savedCursorMode;
    private bool _isCameraEnabled = true;
    private static float _time;
    private static int _score;
    private NewCameraLook cameraLook;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void TogglePause()
    {
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            Cursor.lockState = _savedCursorMode;
            Cursor.visible = false;
            if (cameraLook != null)
            {
                cameraLook.enabled = _isCameraEnabled;
            }
        }
        else
        {
            Time.timeScale = 0;
            _savedCursorMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            if (cameraLook != null)
            {
                _isCameraEnabled = cameraLook.enabled;
                cameraLook.enabled = false;
            }
        }
    }


    public static float GameTime
    {
        get { return _time; }
        set { _time = value; }
    }

    public static int Score
    {
        get { return _score; }
        set { _score = value; }
    }
}