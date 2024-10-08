using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VidaPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public static VidaPlayer instance;
    public float VidaRestante, VidaMaxima;
    public float CantidadInvicibilidad;
    public float ContadorInvisibilidad;

    private SpriteRenderer spriteRender;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        VidaRestante = VidaMaxima;
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ContadorInvisibilidad > 0)
        {
            ContadorInvisibilidad -= Time.deltaTime;

            if (ContadorInvisibilidad <= 0)
            {
                spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, 1f);
            }
        }

        if (VidaRestante <= 0)
        {
            PlayerMovimiento.instancia.DesactivarInput();
            gameObject.SetActive(false);
        }
    }

    public void DañoAlJugador()
    {
        if (ContadorInvisibilidad <= 0)
        {
            VidaRestante--;
            PlayerMovimiento.instancia.animador.SetTrigger("Hurt");
            if (VidaRestante <= 0)
            {
                VidaRestante = 0;
            }
            else
            {
                ContadorInvisibilidad = CantidadInvicibilidad;
                spriteRender.color = new Color(spriteRender.color.r, spriteRender.color.g, spriteRender.color.b, .4f);

                PlayerMovimiento.instancia.KnocckBack();
            }
            CanvasControler.instance.ActualizarCorazones();
        }
    }


}
