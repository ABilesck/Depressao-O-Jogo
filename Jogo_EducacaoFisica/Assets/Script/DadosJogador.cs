using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DadosJogador
{
    public int VidaMaxima;
    public int VidaAtual;
    public int Poder;
    public float[] Posicao;
    public bool Cerebro;

    public DadosJogador (JogadorStatus jogador)
    {
        VidaMaxima = jogador.PontosDeVida;
        VidaAtual = jogador.VidaAtual;
        Poder = jogador.Poder;

        Posicao = new float[3];
        Posicao[0] = jogador.transform.position.x;
        Posicao[1] = jogador.transform.position.y;
        Posicao[2] = jogador.transform.position.z;
        Cerebro = jogador.Cerebro;
    }

}
