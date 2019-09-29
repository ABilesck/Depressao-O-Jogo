﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inimigo : MonoBehaviour
{
    public AssetInimigo asset;
    private int VidaAtual;
    public Slider VidaUI;
    [Space]
    private float Distancia = 1.5f;
    //public Animator animator;
    private bool MovendoParaDireita = true;
    
    [Space(25)]
    public Transform DetectorDeChao;

    public LayerMask Chao;
    [Space]
    public LayerMask Jogador;
    [Space]
    public int Dano;
    public GameObject SangueDoDano;
    public GameObject SangueDaMorte;

    private void Start()
    {
        VidaAtual = asset.VidaMaxima;
        VidaUI.maxValue = asset.VidaMaxima;
        VidaUI.value = VidaUI.maxValue;
    }

    void Update()
    {
        Morrer();

        transform.Translate(Vector2.right * asset.Velocidade * Time.deltaTime);

        RaycastHit2D groundInfo = Physics2D.Raycast(DetectorDeChao.position, Vector2.down, Distancia, Chao);

        if (!groundInfo.collider)
        {
            if (MovendoParaDireita)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                MovendoParaDireita = false;
                VidaUI.SetDirection(Slider.Direction.LeftToRight, false);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                MovendoParaDireita = true;
            }
        }

        if (MovendoParaDireita)
        {
            VidaUI.SetDirection(Slider.Direction.LeftToRight, false);
        }
        else
        {
            VidaUI.SetDirection(Slider.Direction.RightToLeft, false);
        }
    }
    public void LevarDano(int dano)
    {
        Instantiate(SangueDoDano, transform.position, Quaternion.identity);

        if (MovendoParaDireita)
        {
            transform.eulerAngles = new Vector3(0, -180, 0);
            MovendoParaDireita = false;
        }
        else
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            MovendoParaDireita = true;
        }

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
            Instantiate(SangueDaMorte, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
            Debug.Log(gameObject.name + " Morreu");
        }  
    }
    public void Reviver()
    {
        VidaAtual = asset.VidaMaxima;
        VidaUI.value = VidaAtual;
        gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hey");
        if(collision.gameObject.layer == Jogador || collision.CompareTag("Player"))
        {
            collision.GetComponent<JogadorStatus>().LevarDano(Dano);
        }
    }

}
