using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DañoAlJugador : MonoBehaviour
{ 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (VidaPlayer.instance.ContadorInvisibilidad <= 0)
            {
                other.GetComponent<VidaPlayer>().DañoAlJugador();
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            VidaPlayer.instance.DañoAlJugador();
        }
    }
}
