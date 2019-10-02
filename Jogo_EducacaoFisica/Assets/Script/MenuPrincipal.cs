using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    public GameObject detalhes;
    public GameObject Botoes;
    public GameObject Titulo;
    public GameObject MenuOpcoes;
    public JogadorStatus jogador;

    public void NovoJogo()
    {
        SceneManager.LoadScene("Jogo");
    }
    public void Continuar()
    {
        jogador.Carregar();
        SceneManager.LoadScene("Jogo");
    }
    public void Opcoes()
    {
        detalhes.SetActive(false);
        Botoes.SetActive(false);
        Titulo.SetActive(false);
        MenuOpcoes.SetActive(true);
    }
    public void OpcoesSair()
    {
        detalhes.SetActive(true);
        Botoes.SetActive(true);
        Titulo.SetActive(true);
        MenuOpcoes.SetActive(false);
    }
    public void Sair()
    {
        Application.Quit();
        Debug.Log("Saiu");
    }

}
