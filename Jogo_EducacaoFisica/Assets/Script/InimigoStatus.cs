using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoStatus : MonoBehaviour
{
    public AssetInimigo asset;
    private int VidaAtual;
    public Slider VidaUI;
    public GameObject SangueDoDano;
    public GameObject SangueDaMorte;

    private void Start()
    {
        VidaAtual = asset.VidaMaxima;
        VidaUI.maxValue = asset.VidaMaxima;
        VidaUI.value = VidaAtual;
    }

    private void Update()
    {
        Morrer();
    }

    public void LevarDano(int dano)
    {
        Instantiate(SangueDoDano, transform.position, Quaternion.identity);
        VidaAtual -= dano;
        VidaUI.value = VidaAtual;
        Debug.Log(gameObject.name + " Levou " + dano + " de dano");
    }
    private void Morrer()
    {
        if (VidaAtual <= 0)
        {
            JogadorStatus jogador = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorStatus>();
            jogador.Poder += asset.Poder;
            jogador.ContagemCavaleirosBrancos++;
            Instantiate(SangueDaMorte, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Debug.Log(gameObject.name + " Morreu");
        }
    }

}
