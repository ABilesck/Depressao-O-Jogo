using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cerebro : MonoBehaviour
{
    public float Velocidade;
    [Space]
    public GameObject Jogador;
    private bool estaPulando;
    // Start is called before the first frame update
    void Start()
    {
        Jogador = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (estaPulando)
        {
            Vector2 movimento = new Vector2(Jogador.transform.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, movimento, Velocidade * Time.deltaTime);
        }
    }
    public void AtivarPulo()
    {
        estaPulando = !estaPulando;
    }
}
