using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PularBehavior : StateMachineBehaviour
{
    public float Tempo;
    public float TempoMin;
    public float TempoMax;
    [Space]
    public float Velocidade;

    public GameObject Jogador;
    public Transform posJogador;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Jogador = GameObject.Find("Jogador");
        posJogador = Jogador.transform;
        Debug.Log(Jogador.transform.position);
        Tempo = Random.Range(TempoMin, TempoMax);
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (Tempo <= 0)
        {
            animator.SetTrigger("Parado");
        }
        else
        {
            Tempo -= Time.deltaTime;
        }

        Vector2 alvo = new Vector2(posJogador.position.x, animator.transform.position.y);
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, alvo, Velocidade * Time.deltaTime);
        
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
