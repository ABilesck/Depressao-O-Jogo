using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorAreaDoChefe : MonoBehaviour
{
    public GameObject ParedeInvisivel;
    public GameObject BarraDeVida;
    public GameObject Chefe;
    public GameObject Jogador;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            Jogador = collision.gameObject;

        if (!Jogador.GetComponent<JogadorStatus>().Cerebro)
        {
            ParedeInvisivel.SetActive(true);
            Invoke("ChamarChefe", 1f);
        }
    }
    private void ChamarChefe()
    {
        Chefe.SetActive(true);
        BarraDeVida.SetActive(true);
    }
}
