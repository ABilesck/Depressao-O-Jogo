using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorAreaDoChefe : MonoBehaviour
{
    public GameObject ParedeInvisivel;
    public GameObject BarraDeVida;
    public GameObject Chefe;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ParedeInvisivel.SetActive(true);
        Invoke("ChamarChefe", 0.75f);
    }
    private void ChamarChefe()
    {
        Chefe.SetActive(true);
        BarraDeVida.SetActive(true);
    }
}
