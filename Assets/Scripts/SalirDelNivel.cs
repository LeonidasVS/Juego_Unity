using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDelNivel : MonoBehaviour
{
    public static SalirDelNivel instance;
    public bool tocoPointFinalizador;

    private void Awake()
    {
        instance = this;    
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            tocoPointFinalizador = true;
            LevelManager.instance.TerminarNivel();
        }
        else
        {
            tocoPointFinalizador = false;
        }
    }
}
