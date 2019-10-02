using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float tempoDeEspera;
    public float TempoEntreAtaque;

    public Transform PosAtaque;
    public float Alcance;
    public LayerMask InimigoLM;
    public int Dano;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        if(tempoDeEspera <= 0)
        {
            if (Input.GetButtonDown("Ataque"))
            {
                animator.SetTrigger("Ataque");
                
                tempoDeEspera = TempoEntreAtaque;
                
            }
            
        }
        else
        {
            tempoDeEspera -= Time.deltaTime;
        }
    }

    public void Atacar()
    {
        Collider2D[] InimigosParaBater = Physics2D.OverlapCircleAll(
                    PosAtaque.position, Alcance, InimigoLM);

        for (int i = 0; i < InimigosParaBater.Length; i++)
        {
            if (InimigosParaBater[i].GetComponent<Inimigo>() != null)
            {
                InimigosParaBater[i].GetComponent<Inimigo>().LevarDano(Dano);
            }
            else if (InimigosParaBater[i].GetComponent<MotorCerebro>() != null)
            {
                InimigosParaBater[i].GetComponent<MotorCerebro>().LevarDano(Dano);

            }
            else if (InimigosParaBater[i].GetComponent<InimigoStatus>() != null)
            {
                InimigosParaBater[i].GetComponent<InimigoStatus>().LevarDano(Dano);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(PosAtaque.position, Alcance);
    }
}
