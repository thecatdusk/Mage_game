using UnityEngine;

public class creditos : MonoBehaviour
{
    [Header("Painéis de UI")]
    public GameObject panelMenu;
    public GameObject panelOpcoes;
    public GameObject panelControles;
    public GameObject panelCreditos;

    public void AbrirOpcoes()
    {
        panelMenu.SetActive(false);
        panelOpcoes.SetActive(true);
        panelControles.SetActive(false);
        panelCreditos.SetActive(false);
    }

    public void AbrirControles()
    {
        panelMenu.SetActive(false);
        panelOpcoes.SetActive(false);
        panelControles.SetActive(true);
        panelCreditos.SetActive(false);
    }

    public void VoltarParaOpcoes()
    {
        panelControles.SetActive(false);
        panelOpcoes.SetActive(true);
    }

    public void VoltarParaMenu()
    {
        panelOpcoes.SetActive(false);
        panelMenu.SetActive(true);
    }
}
