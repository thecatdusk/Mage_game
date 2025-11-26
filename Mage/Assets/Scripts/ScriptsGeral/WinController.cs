using UnityEngine;
using UnityEngine.SceneManagement;

public class WinController : MonoBehaviour
{
    public GameObject winScreenUI; // arraste sua tela aqui

    void Start()
    {
        winScreenUI.SetActive(false); // começa desligado
    }

    void Update()
    {
        // APERTAR V → VENCER
        if (Input.GetKeyDown(KeyCode.V))
        {
            WinGame();
        }
    }

    public void WinGame()
    {
        Debug.Log("O jogador venceu o jogo!");

        Time.timeScale = 0f;
        winScreenUI.SetActive(true);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    // Se quiser botão para voltar ao menu:
    public void BackToMenu(string menuScene)
    {
        Time.timeScale = 1f;
    }
}