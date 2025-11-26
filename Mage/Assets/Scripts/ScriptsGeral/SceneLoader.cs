using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   public bool pauseOnESC = false;

    public GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (pauseOnESC && Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;
        pausePanel.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
        Cursor.visible = isPaused;
        Cursor.lockState = isPaused ? CursorLockMode.None : CursorLockMode.Locked;
    }


    public void LoadScene(string sceneName)
    {

        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }


    public void Quit()
    {
        Application.Quit();

    }
}