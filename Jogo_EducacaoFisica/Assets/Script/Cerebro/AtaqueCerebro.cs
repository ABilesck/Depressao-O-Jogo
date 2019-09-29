using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtaqueCerebro : MonoBehaviour
{
    public int Dano;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Player"))
        {
            JogadorStatus jogador = collision.gameObject.GetComponent<JogadorStatus>();
            if(jogador != null)
            {
                jogador.LevarDano(Dano);
            }
        }
    }
}
