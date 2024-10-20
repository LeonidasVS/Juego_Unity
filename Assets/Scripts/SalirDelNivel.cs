using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SalirDelNivel : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            LevelManager.instance.TerminarNivel();
        }
    }
}
