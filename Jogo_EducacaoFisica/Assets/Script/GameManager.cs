using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject jogador;
    public GameObject[] inimigosParaResurgir;

    private void Start()
    {
        inimigosParaResurgir = GameObject.FindGameObjectsWithTag("Inimigo");
    }

    public void btnResurgirJogador()
    {
        jogador.GetComponent<JogadorStatus>().Respawnar();
        //GameObject[] inimigosParaResurgir = GameObject.FindGameObjectsWithTag("Inimigo");
        foreach (GameObject inimigo in inimigosParaResurgir)
        {
            inimigo.GetComponent<Inimigo>().Reviver();
        }
    }
}
