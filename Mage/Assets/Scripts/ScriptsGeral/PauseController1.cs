using UnityEngine;

public class PauseController1 : MonoBehaviour
{
    [Header("Painéis de UI")]
    public GameObject painelPause;        // ESC
    public GameObject painelOpcoes;       // OptionsPanel
    public GameObject painelControles;    // ControlesPanel

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
                AbrirPause();
            else
                FecharTudo();
        }
    }

    // --- PAUSE ---
    public void AbrirPause()
    {
        FecharTudo();
        painelPause.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }

    // --- OPÇÕES ---
    public void AbrirOpcoes()
    {
        painelPause.SetActive(false);
        painelControles.SetActive(false);
        painelOpcoes.SetActive(true);
    }

    // --- CONTROLES ---
    public void AbrirControles()
    {
        painelOpcoes.SetActive(false);
        painelControles.SetActive(true);
    }

    // --- VOLTAR ---
    public void VoltarParaPause()
    {
        painelOpcoes.SetActive(false);
        painelControles.SetActive(false);
        painelPause.SetActive(true);
    }

    public void FecharTudo()
    {
        painelPause.SetActive(false);
        painelOpcoes.SetActive(false);
        painelControles.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}
