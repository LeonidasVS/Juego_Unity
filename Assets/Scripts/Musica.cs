using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Musica : MonoBehaviour
{
    public static Musica instance;
    public AudioSource musicaFondo,musicaGO;

    private void Awake()
    {
        instance = this;
    }
    public void CambiarMusica()
    {
        musicaFondo.Stop();
        musicaGO.Play();
        musicaGO.loop = true;
    }
}
