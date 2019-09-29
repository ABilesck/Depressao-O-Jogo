using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JogadorPoderes : MonoBehaviour
{
    public Console console;
    [Space]
    public JogadorStatus Status;
    [Space(50)]
    public int MontanteDeCura;
    public int CustoDeCura;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if(Status.Poder >= CustoDeCura && Status.VidaAtual < Status.PontosDeVida)
            {
                Status.VidaAtual += MontanteDeCura;
                Status.VidaSlider.value = Status.VidaAtual;
                Status.Poder -= CustoDeCura;
            }
            else if(Status.VidaAtual >= Status.PontosDeVida)
            {
                console.EscreverNoConsole("Sua vida ja esta cheia!");

            }else if(Status.Poder < CustoDeCura)
            {
                console.EscreverNoConsole("Poder insuficiente!");
            }
        }
    }
}
