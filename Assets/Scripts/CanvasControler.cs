using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    public static CanvasControler instance;

    public Image heart1, heart2, heart3;

    public Sprite CorazonLleno, CorazonVacio, CorazonMedio;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ActualizarCorazones()
    {
        switch (VidaPlayer.instance.VidaRestante)
        {
            case 6:
                heart1.sprite = CorazonLleno;
                heart2.sprite = CorazonLleno;
                heart3.sprite = CorazonLleno;
                break;
            case 5:
                heart1.sprite = CorazonLleno;
                heart2.sprite = CorazonLleno;
                heart3.sprite = CorazonMedio;
                break;
            case 4:
                heart1.sprite = CorazonLleno;
                heart2.sprite = CorazonLleno;
                heart3.sprite = CorazonVacio;
                break;

            case 3:
                heart1.sprite = CorazonLleno;
                heart2.sprite = CorazonMedio;
                heart3.sprite = CorazonVacio;
                break;
            case 2:
                heart1.sprite = CorazonLleno;
                heart2.sprite = CorazonVacio;
                heart3.sprite = CorazonVacio;
                break;
            case 1:
                heart1.sprite = CorazonMedio;
                heart2.sprite = CorazonVacio;
                heart3.sprite = CorazonVacio;
                break;
            case 0:
                heart1.sprite = CorazonVacio;
                heart2.sprite = CorazonVacio;
                heart3.sprite = CorazonVacio;
                break;
            default:
                heart1.sprite = CorazonVacio;
                heart2.sprite = CorazonVacio;
                heart3.sprite = CorazonVacio;
                break;
        }
    }

}
