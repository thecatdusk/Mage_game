using UnityEngine;
using UnityEngine.SceneManagement;


public class Telas : MonoBehaviour

{
    [SerializeField] public string nomeDoLevelDeJogo;
    [SerializeField] public GameObject painelEsc;
    [SerializeField] public GameObject painelOpcoes;
    [SerializeField] public GameObject painelControles;
    [SerializeField] public GameObject painelFimdejogo;
    [SerializeField] public GameObject painelWin;
    public bool painelEscAtivo = false;
    public bool painelOpcoesAtivo = false;
    public bool painelControlesAtivo = false;
    public bool painelFimdejogoAtivo = false;
    public bool painelWinAtivo = false;

    public void PausarJogo()
    {
        if (painelEscAtivo == false && painelFimdejogoAtivo == false && painelWinAtivo == false)
        {
            painelEscAtivo = true;
            painelOpcoesAtivo = false;
            painelControlesAtivo = false;
        }
     
    }
    public void Opcoes()
    {
        painelEscAtivo = false;
        painelOpcoesAtivo = true;
        painelControlesAtivo = false;
    }
    public void Controles()
    {
        painelEscAtivo = false;
        painelOpcoesAtivo = false;
        painelControlesAtivo = true;
    }
    public void Win()
    {
        painelFimdejogoAtivo = false;
        painelEscAtivo = false;
        painelWinAtivo = true;
    }
    public void Fimdejogo()
    {
        painelFimdejogoAtivo = true;
        painelEscAtivo = false;
        painelWinAtivo = false;
    }
    public void MenuPrincipal()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nomeDoLevelDeJogo);
    }
    public void ReiniciarJogo()
    {
        Time.timeScale = 1f;
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }

    public void DespausarJogo()
    {
        if (painelEscAtivo == true && painelFimdejogoAtivo == false && painelWinAtivo == false)
        {
            painelEscAtivo = false;
            painelOpcoesAtivo = false;
            painelControlesAtivo = false;
            Debug.Log(painelEsc.activeSelf);
        }
    }

    void Start()
    {
        painelEsc.SetActive(painelEscAtivo);
        painelOpcoes.SetActive(painelOpcoesAtivo);
        painelControles.SetActive(painelControlesAtivo);
        painelFimdejogo.SetActive(painelFimdejogoAtivo);
        painelWin.SetActive(painelWinAtivo);
    }
    void Update()
    {
        painelEsc.SetActive(painelEscAtivo);
        painelOpcoes.SetActive(painelOpcoesAtivo);
        painelControles.SetActive(painelControlesAtivo);
        painelFimdejogo.SetActive(painelFimdejogoAtivo);
        painelWin.SetActive(painelWinAtivo);
        if (painelEscAtivo || painelFimdejogoAtivo || painelWinAtivo || painelOpcoesAtivo || painelControlesAtivo)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Time.timeScale = 1f;
        }
    }
}


