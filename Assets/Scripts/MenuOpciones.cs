using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpciones : MonoBehaviour
{

    public Slider slider, slider2;
    public float sliderValue, sliderValue2;
    public Image panelBrillo;
    //public Toggle toggle;
    // Start is called before the first frame update
    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("volumenAudio", .3f);
        AudioListener.volume = slider.value;

        slider2.value = PlayerPrefs.GetFloat("Brillo", .3f);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider2.value);
    }

    public void ChageSlider(float valor)
    {
        sliderValue = valor;
        PlayerPrefs.SetFloat("volumenAudio", sliderValue);
        AudioListener.volume = slider.value;
    }

    public void ChageSlider2(float valor2)
    {
        sliderValue2 = valor2;
        PlayerPrefs.SetFloat("Brillo", sliderValue2);
        panelBrillo.color = new Color(panelBrillo.color.r, panelBrillo.color.g, panelBrillo.color.b, slider2.value);
    }
}
