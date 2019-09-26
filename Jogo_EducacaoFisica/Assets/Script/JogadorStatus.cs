using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JogadorStatus : MonoBehaviour
{
    public int PontosDeVida;
    [SerializeField]
    public int VidaAtual;
    public Slider VidaSlider;
    public int Lagrimas;
    public Slider sldPoder;
    [Space(30)]
    public Transform checkpoint;
    //private bool morreu;
    [Space(30)]
    public GameObject TelaDeMorte;
    public Player player;
    public bool PodeLevarDano;
    public float TempoParaDano;
    [Space]
    public GameObject SangueDano;
    [Space]
    [Header("Chefões")]
    public bool Cerebro;

    private void Start()
    {
        VidaSlider.maxValue = PontosDeVida;
        VidaAtual = PontosDeVida;
        VidaSlider.value = VidaSlider.maxValue;
    }

    private void Update()
    {
        Morrer();
        if(Lagrimas >= sldPoder.maxValue)
        {
            Lagrimas = (int)sldPoder.maxValue;
            sldPoder.value = Lagrimas;
        }
        else
        {
            sldPoder.value = Lagrimas;
        }
    }


    public void LevarDano(int dano)
    {
        if (PodeLevarDano)
        {
            Instantiate(SangueDano, transform.position, Quaternion.identity);
            PodeLevarDano = false;
            VidaAtual -= dano;
            VidaSlider.value = VidaAtual;
            Debug.Log("Jogador levou dano");
            Invoke("HabilitarDano", TempoParaDano);
        }
        else
        {
            Debug.Log("Jogador ainda nao pode levar dano");
        }
    }
    public void Respawnar()
    {
        Time.timeScale = 1;
        transform.position = checkpoint.position;
        VidaSlider.maxValue = PontosDeVida;
        VidaAtual = PontosDeVida;
        VidaSlider.value = VidaSlider.maxValue;
        TelaDeMorte.SetActive(false);
    }
    public void Morrer()
    {
        if(VidaAtual <= 0)
        {
            Time.timeScale = 0;
            TelaDeMorte.SetActive(true);
        }
    }
    private void HabilitarDano()
    {
        if (!PodeLevarDano)
            PodeLevarDano = true;
    }
}
