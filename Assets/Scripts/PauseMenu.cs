using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Camera _mainCamera;
    [SerializeField] private GameObject _pauseMenu;

    private static bool isPauseGame;
    private float _stopTime = 1f;
    private float _runTime = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPauseGame)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        _pauseMenu.SetActive(false);
        Time.timeScale = _stopTime;
        isPauseGame = false;
        _mainCamera.GetComponent<NewCameraLook>().enabled = true;
    }

    public void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        _pauseMenu.SetActive(true);
        Time.timeScale = _runTime;
        isPauseGame = true;
        _mainCamera.GetComponent<NewCameraLook>().enabled = false;
    }

    public void LoadMenu()
    {
        Time.timeScale = _stopTime;
        SceneManager.LoadScene(0);
    }
}