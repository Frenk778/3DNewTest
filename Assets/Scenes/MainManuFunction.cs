using UnityEngine;
using UnityEngine.SceneManagement;

public class MainManuFunction : MonoBehaviour
{
    internal static float time;
    internal static int score;

    private bool cameraEnabled = true;
    private CursorLockMode savedCursorMode;

    public void Start()
    {

    }

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
            Cursor.lockState = savedCursorMode;
            Cursor.visible = false;
            Camera.main.GetComponent<NewCameraLook>().enabled = cameraEnabled;
        }
        else
        {
            Time.timeScale = 0;
            savedCursorMode = Cursor.lockState;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            cameraEnabled = Camera.main.GetComponent<NewCameraLook>().enabled;
            Camera.main.GetComponent<NewCameraLook>().enabled = false;
        }
    }
}