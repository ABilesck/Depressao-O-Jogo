using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MenuOpcoes : MonoBehaviour
{
    public AudioMixer audioMixer;

    public Dropdown dropdownResolucoes;

    Resolution[] resolutions;

    private void Start()
    {
        resolutions = Screen.resolutions;

        dropdownResolucoes.ClearOptions();

        List<string> opcoes = new List<string>();

        int indexResolucoes = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string opt = $"{resolutions[i].width} x {resolutions[i].height}";
            opcoes.Add(opt);

            if (resolutions[i].Equals(Screen.currentResolution))
                indexResolucoes = i;
        }

        dropdownResolucoes.AddOptions(opcoes);
        dropdownResolucoes.value = indexResolucoes;
        dropdownResolucoes.RefreshShownValue();
    }

    public void SetVol (Slider VolumeSlider)
    {
        audioMixer.SetFloat("Volume", VolumeSlider.value);
    }

    public void SetQualidade(Dropdown dropdownQualidade)
    {
        int index = dropdownQualidade.value;
        QualitySettings.SetQualityLevel(index);
        Debug.Log(index);
    }
    public void SetTelaCheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }
    public void SetResolucao(Dropdown dropdownRes)
    {
        Resolution res = resolutions[dropdownRes.value];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }
}
