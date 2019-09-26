using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortaComAlavanca : MonoBehaviour
{
    public GameObject AlavancaCorrespondente;
    public GameObject CanvasEntrar;
    [SerializeField]
    private Console console;
    [Space]
    public GameObject PortaParaSaida;

    private void Start()
    {
        console = GameObject.FindGameObjectWithTag("Manager").GetComponent<Console>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CanvasEntrar.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CanvasEntrar.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            if (Input.GetButtonDown("Interagir"))
            {
                bool PodeEntrar = AlavancaCorrespondente.GetComponent<Alavanca>().Ativado;
                if (PodeEntrar)
                {
                    //entrar
                    console.EscreverNoConsole("Entrou!");
                    console.FadeOut();
                    collision.gameObject.transform.position = PortaParaSaida.transform.position;
                    Debug.Log("Entrou");
                    console.Fadein();

                }
                else
                {
                    console.EscreverNoConsole("A porta esta trancada!");
                    Debug.Log("Está trancado");
                }
            }
        }
        
    }

}
