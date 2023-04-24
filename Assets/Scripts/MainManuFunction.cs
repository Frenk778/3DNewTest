using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuFunction : MonoBehaviour
{
    private static float _time;
    private static int _score;
    private bool _isCameraEnabled = true;
    private CursorLockMode _savedCursorMode;

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
            Camera.main.GetComponent<NewCameraLook>().enabled = _isCameraEnabled;
        }
        else
        {
            Time.timeScale = 0;
            _savedCursorMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            _isCameraEnabled = Camera.main.GetComponent<NewCameraLook>().enabled;
            Camera.main.GetComponent<NewCameraLook>().enabled = false;
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