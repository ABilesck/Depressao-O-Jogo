using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPausa : MonoBehaviour
{
    public static bool JogoPausado;
    public GameObject MenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JogoPausado)
            {
                Resumir();
            }
            else
            {
                Pausar();
            }
        }
    }

    public void Resumir()
    {
        MenuUI.SetActive(false);
        Time.timeScale = 1;
        JogoPausado = false;
    }

    void Pausar()
    {
        MenuUI.SetActive(true);
        Time.timeScale = 0;
        JogoPausado = true;
    }

    public void SairDoJogo()
    {
        Application.Quit();
    }
}
