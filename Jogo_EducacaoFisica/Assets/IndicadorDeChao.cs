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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        TemChao = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        TemChao = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        TemChao = true;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        TemChao = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TemChao = false;
    }
}
