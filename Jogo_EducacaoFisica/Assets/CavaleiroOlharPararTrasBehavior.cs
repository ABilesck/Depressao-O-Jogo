using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroOlharPararTrasBehavior : StateMachineBehaviour
{
    private float tempo;
    public float TempoMin;
    public float TempoMax;
    public bool AndandoParaDireita;
    private int prxAcao;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        tempo = Random.Range(TempoMin, TempoMax);
        prxAcao = Random.Range(0, 2);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(tempo <= 0)
        {
            AndandoParaDireita = animator.GetBool("AndandoParaDireita");
            if (AndandoParaDireita)
            {
                animator.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                //AndarParaDireita = false;
                animator.SetBool("AndandoParaDireita", false);
            }
            else if (!AndandoParaDireita)
            {
                animator.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                //AndarParaDireita = true;
                animator.SetBool("AndandoParaDireita", true);
            }

            if(prxAcao == 0)
                animator.SetTrigger("parar");
            else if(prxAcao == 1)
                if (animator.GetBool("TemChao"))
                    animator.SetTrigger("andar");
                else
                    animator.SetTrigger("parar");

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
