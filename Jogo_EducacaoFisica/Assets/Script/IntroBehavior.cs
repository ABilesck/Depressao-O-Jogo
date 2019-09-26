using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBehavior : StateMachineBehaviour
{
    private int aleatorio;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        aleatorio = Random.Range(0, 2);

        if(aleatorio == 0)
        {
            animator.SetTrigger("Parado");
        }
        else
        {
            animator.SetTrigger("Pular");
        }
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
