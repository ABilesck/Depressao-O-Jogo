using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCavaleiroBranco : MonoBehaviour
{
    public Transform DetectorDeChao;
    public LayerMask Chao;
    public IndicadorDeJogador IndicadorDeJogador;
    public bool TemJogador;
    public Animator animator;
    public bool AndarParaDireita;
    private void Update()
    {
        AndarParaDireita = animator.GetBool("AndandoParaDireita");
        RaycastHit2D groundInfo = Physics2D.Raycast(DetectorDeChao.position, Vector2.down, 3, Chao);
        if (!groundInfo.collider)
        {
            if (AndarParaDireita)
            {
                transform.eulerAngles = new Vector3(0, -180, 0);
                //MovendoParaDireita = false;
                animator.SetBool("AndandoParaDireita", false);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
                //MovendoParaDireita = true;
                animator.SetBool("AndandoParaDireita", true);
            }
        }

        TemJogador = IndicadorDeJogador.TemJogador;
        animator.SetBool("TemJogador", TemJogador);
        if (TemJogador)
        {
            animator.SetTrigger("parar");
            float distancia = Vector2.Dot(transform.right, IndicadorDeJogador.PosJogador.right);
            Debug.Log(distancia);
        }
    }
}
