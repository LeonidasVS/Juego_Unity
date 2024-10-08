using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Player")
        {
            PlayerMovimiento.instancia.animador.Rebind();
            //LevelManager.instance.RespownPlayer();
            VidaPlayer.instance.DañoAlJugador();
            LevelManager.instance.RespownPlayer();
        }
    }
}
