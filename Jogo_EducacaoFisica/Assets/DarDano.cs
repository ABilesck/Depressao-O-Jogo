using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarDano : MonoBehaviour
{
    public int Dano;
    public AssetInimigo asset;

    private void Awake()
    {
        asset = gameObject.GetComponentInParent<InimigoStatus>().asset;
        Dano = asset.Dano;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<JogadorStatus>().LevarDano(Dano);
        }
    }
}
