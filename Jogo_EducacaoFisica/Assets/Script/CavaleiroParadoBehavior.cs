using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroParadoBehavior : StateMachineBehaviour
{
    private float tempo;
    public float TempoMin;
    public float TempoMax;
    // bool TemChao;
    private bool TemJogador;
    public int Acao;
    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tempo = Random.Range(TempoMin, TempoMax);
        //DetectorDeChao = animator.transform.GetChild(0);
        Acao = Random.Range(0, 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //TemChao = animator.GetBool("TemChao");
        TemJogador = animator.GetBool("TemJogador");
        if (tempo <= 0)
        {
            if (TemJogador)
                animator.SetTrigger("atacar");

            switch (Acao)
            {
                case 0:
                    if (!TemJogador)
                        animator.SetTrigger("andar");
                    Acao = Random.Range(0, 2);
                    break;
                case 1:
                    if(!TemJogador)
                        animator.SetTrigger("OlharParaTras");
                    break;
            }
            
        }
        else
        {
            tempo -= Time.deltaTime;
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
