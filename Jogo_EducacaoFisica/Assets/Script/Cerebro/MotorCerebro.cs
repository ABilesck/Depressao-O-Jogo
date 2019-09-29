using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotorCerebro : MonoBehaviour
{
    public float VidaMaxima;
    private float VidaAtual;
    public Slider SliderVida;
    [Space]
    public int Lagrimas;
    [Space]
    public GameObject SangueDano;
    public GameObject SangueMorte;

    // Start is called before the first frame update
    void Start()
    {
        VidaAtual = VidaMaxima;
        SliderVida.maxValue = VidaMaxima;
        SliderVida.value = VidaMaxima;

    }

    private void Update()
    {
        Morrer();
    }

    public void LevarDano(int dano)
    {
        Instantiate(SangueDano, transform.position, Quaternion.identity);
        
        VidaAtual -= dano;
        SliderVida.value = VidaAtual;
        Debug.Log(gameObject.name + " Levou " + dano + " de dano");
    }

    private void Morrer()
    {
        if (VidaAtual <= 0)
        {
            JogadorStatus jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorStatus>();
            jogador.Cerebro = true;
            jogador.Poder += Lagrimas;
            Instantiate(SangueMorte, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Debug.Log(gameObject.name + " Morreu");
        }
    }
}
