using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadoBehavior : StateMachineBehaviour
{
    public float Tempo;
    public float TempoMin;
    public float TempoMax;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Tempo = Random.Range(TempoMin, TempoMax);
    }
    
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(Tempo <= 0)
        {
            animator.SetTrigger("Pular");
        }
        else
        {
            Tempo -= Time.deltaTime;
        }
    }
    
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
