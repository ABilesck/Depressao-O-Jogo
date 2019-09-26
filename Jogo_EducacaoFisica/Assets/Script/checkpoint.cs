using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public SpriteRenderer bandeira;
    public Sprite BandeiraVerde;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        JogadorStatus jogador = collision.GetComponent<JogadorStatus>();
        if (jogador != null)
        {
            jogador.checkpoint = transform;
            bandeira.sprite = BandeiraVerde;
        }

    }
}
