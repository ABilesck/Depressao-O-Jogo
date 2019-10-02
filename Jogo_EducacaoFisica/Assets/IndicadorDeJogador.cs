using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorDeJogador : MonoBehaviour
{
    public bool TemJogador;
    public Transform PosJogador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TemJogador = true;
            PosJogador = collision.transform;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TemJogador = false;
            PosJogador = null;
        }
    }
}
