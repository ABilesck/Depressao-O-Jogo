using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndicadorDeChao : MonoBehaviour
{
    public bool TemChao;
    public LayerMask chao;
    public Animator anim;

    private void Update()
    {
        anim.SetBool("TemChao", TemChao);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Chao"))
        {
            TemChao = true;
        }
        else
        {
            TemChao = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Chao"))
        {
            TemChao = false;
        }
        else
        {
            TemChao = true;
        }
    }
}
