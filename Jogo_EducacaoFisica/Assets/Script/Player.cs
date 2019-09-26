using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody2D rb;
    public Animator animator;
    [Space]
    public Transform Pes;
    public LayerMask Chao;
    public float Raio;
    [Space]
    public float Velocidade;
    public float ForcaDePulo;
    public float TempoDePulo;
    private float axis;
    [HideInInspector]
    public bool Direita = true;

    private bool NoChao;
    private float contadorTempoDePulo;
    public bool estaPulando;

    private void Update()
    {
        NoChao = Physics2D.OverlapCircle(Pes.position, Raio, Chao);
        animator.SetBool("pular", !NoChao);
        if (axis < 0 && Direita)
        {
            Virar();
        }
        else if (axis > 0 && !Direita)
        {
            Virar();
        }

        if (NoChao && Input.GetButtonDown("Jump"))
        {
            estaPulando = true;
            contadorTempoDePulo = TempoDePulo;
            rb.velocity = Vector2.up * ForcaDePulo;
        }
        if (Input.GetButton("Jump") && estaPulando)
        {
            if (contadorTempoDePulo > 0)
            {
                rb.velocity = Vector2.up * ForcaDePulo;
                contadorTempoDePulo -= Time.deltaTime;
            }
            else
            {
                estaPulando = false;
            }
        }
        if (Input.GetButtonUp("Jump"))
        {
            estaPulando = false;
        }

    }

    private void FixedUpdate()
    {
        axis = Input.GetAxisRaw("Horizontal");

        if(axis != 0)
            animator.SetBool("Andando", true);
        else
            animator.SetBool("Andando", false);
        rb.velocity = new Vector2(axis * Velocidade, rb.velocity.y);
    }
    private void Virar()
    {
        Direita = !Direita;
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
    }
}
