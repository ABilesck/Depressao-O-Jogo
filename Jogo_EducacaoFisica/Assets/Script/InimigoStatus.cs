using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InimigoStatus : MonoBehaviour
{
    public AssetInimigo asset;
    private int vidaAtual;
    public Slider VidaUI;

    private void Start()
    {
        vidaAtual = asset.VidaMaxima;
        VidaUI.maxValue = asset.VidaMaxima;
        VidaUI.value = vidaAtual;
    }

}
