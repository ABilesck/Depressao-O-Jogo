using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Porta : MonoBehaviour
{
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
        if (Input.GetButtonDown("Interagir"))
        {
            //entrar
            console.EscreverNoConsole("Entrou!");
            console.FadeOut();
            collision.gameObject.transform.position = PortaParaSaida.transform.position;
            Debug.Log("Entrou");
            console.Fadein();
        }
    }
}
