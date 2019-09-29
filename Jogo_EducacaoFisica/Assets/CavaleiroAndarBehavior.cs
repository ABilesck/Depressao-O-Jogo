using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CavaleiroAndarBehavior : StateMachineBehaviour
{
    private float tempo;
    public float TempoMin;
    public float TempoMax;
    public AssetInimigo asset;
    public bool AndarParaDireita;
    //public Transform DetectorDeChao;
    public bool TemChao;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //DetectorDeChao = animator.transform.GetChild(0);
        tempo = Random.Range(TempoMin, TempoMax);
        asset = animator.gameObject.GetComponent<InimigoStatus>().asset;
        TemChao = animator.GetBool("TemChao");
        if (TemChao)
            AndarParaDireita = (Random.Range(0, 2) == 0);
        if (!TemChao)
        {
            Debug.Log("Nao tem chao");
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (tempo <= 0 && TemChao)
        {
            animator.SetTrigger("parar");
        }
        else
        {
            tempo -= Time.deltaTime;
        }
        animator.SetBool("AndandoParaDireita", AndarParaDireita);
        animator.gameObject.transform.Translate(Vector2.right * asset.Velocidade * Time.deltaTime);

        //RaycastHit2D groundInfo = Physics2D.Raycast(DetectorDeChao.position, Vector2.down, 10, Chao);
        //TemChao = DetectorDeChao.GetComponent<IndicadorDeChao>().TemChao;
        TemChao = animator.GetBool("TemChao");

        if (!TemChao)
        {
            animator.SetTrigger("parar");
        }

        if (TemChao)
        {
            if (AndarParaDireita)
            {
                animator.gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
                //AndarParaDireita = false;
            }
            else if (!AndarParaDireita)
            {
                animator.gameObject.transform.eulerAngles = new Vector3(0, -180, 0);
                //AndarParaDireita = true;
            }
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
