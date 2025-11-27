using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    public GameObject pauseMenu;       // Canvas geral (não use este para ativar/desativar telas específicas)
    public GameObject mainPausePanel;  // Painel com Continuar / Opções / Sair
    public GameObject optionsPanel;    // Seu painel de Opções

    private bool isPaused = false;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Garante que apenas o menu principal mostre quando abrir a tela ESC
        mainPausePanel.SetActive(true);
        optionsPanel.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        mainPausePanel.SetActive(true);
        optionsPanel.SetActive(false);

        Time.timeScale = 0f;
        isPaused = true;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Options()
    {
        mainPausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void BackToPauseMenu()
    {
        optionsPanel.SetActive(false);
        mainPausePanel.SetActive(true);
    }

    public void GoToMenu()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("Menu");
    }
}
