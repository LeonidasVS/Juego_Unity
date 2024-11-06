using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;

public class CanvasControler : MonoBehaviour
{
    public static CanvasControler instance;

    public Image heart1, heart2, heart3;

    public Sprite CorazonLleno, CorazonVacio, CorazonMedio;

    public  Image fadeScreen;
    public float fadeSpeed,tiempo;
    private bool shouldFadeToBlack, shouldFadeFromWhite, pantallaFinal,PantallaGameOver;
    public GameObject NivelCompletadoText, fondoFinal,gameOver;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        FadeFromBlack();
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldFadeToBlack)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 1f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a==1f)
            {
                shouldFadeToBlack = false;
            }
        }

        if (shouldFadeFromWhite)
        {
            fadeScreen.color = new Color(fadeScreen.color.r, fadeScreen.color.g, fadeScreen.color.b, Mathf.MoveTowards(fadeScreen.color.a, 0f, fadeSpeed * Time.deltaTime));

            if (fadeScreen.color.a == 0f)
            {
                shouldFadeFromWhite = false;
            }
        }
        if (VidaPlayer.instance.VidaRestante<=0)
        {
            tiempo -= Time.deltaTime;

            if (tiempo <= 0)
            {
                CanvasControler.instance.FadeFromBlack();
                tiempo = 0;
                GameOver();
            }

        }
        if (pantallaFinal)
        {
            fondoFinal.SetActive(true);
        }

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

    public void FadeToBlack()
    {
        shouldFadeToBlack = true;
        shouldFadeFromWhite = false;
        pantallaFinal = false;
        
    }

    public void FadeFromBlack()
    {
        shouldFadeToBlack = false;
        pantallaFinal= false;
        shouldFadeFromWhite = true;  
    }

    public void FadePantallaFinal()
    {
        shouldFadeToBlack = false;
        pantallaFinal = true;
        shouldFadeFromWhite =false;
    }

    public void GameOver()
    {
        StartCoroutine(GameOve());
    }

    public IEnumerator GameOve()
    {
        yield return new WaitForSeconds(1f);
        CanvasControler.instance.gameOver.SetActive(true);
    }
}
