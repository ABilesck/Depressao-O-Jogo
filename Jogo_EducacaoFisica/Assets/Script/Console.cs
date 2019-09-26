using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Console : MonoBehaviour
{
    public Text TextoDoConsole;
    public Image TelaPreta;
    public float TempoParaFade;

    public void EscreverNoConsole(string texto)
    {
        TextoDoConsole.text += $"{texto}\n";
        Invoke("LimpaConsole", 2.5f);
    }
    public void FadeOut()
    {
        TelaPreta.color = Color.black;
        TelaPreta.canvasRenderer.SetAlpha(0.0f);
        TelaPreta.CrossFadeAlpha(1.0f, TempoParaFade, false);
    }
    public void Fadein()
    {
        TelaPreta.color = Color.black;
        TelaPreta.canvasRenderer.SetAlpha(1.0f);
        TelaPreta.CrossFadeAlpha(0.0f, TempoParaFade, false);
    }
    private void LimpaConsole()
    {
        TextoDoConsole.text = "";
    }
}
