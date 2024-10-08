using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerMovimiento : MonoBehaviour
{
    // Start is called before the first frame update
    //#region Variables
    //public float JumpFource;

    public static PlayerMovimiento instancia;

    private void Awake()
    {
        instancia = this;
    }

    [Header("Movimineto")]
    public float Speed;

    [Header("Salto")]
    public float JumpForce;

    [Header("Componentes")]
    public float Horizontal;
    public Rigidbody2D Rigidbody2D;
    public SpriteRenderer sprite;
    public GameObject bala;
    Vector3 direcion;

    [Header("Grounded")]
    private bool isGrounded;
    public Transform Trans;
    public LayerMask elpiso;
    //private bool Grounded;

    [Header("Animaciones")]
    public Animator animador;
    //#endregion
    public float KnockBackLongitud, KnockBackFuerza,tiempoPorAnimacion;
    private float KnockBackContador;
    private bool SigueVivo = true;
    private float LastSHoot;
    void Start()
    {
        //Rigidbody2D=GetComponent<Rigidbody2D>();
        animador = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        animador.SetBool("Caminar", Horizontal != 0.0f);
        animador.SetBool("IsGrounded", isGrounded);

        if (SigueVivo)
        {
            if (KnockBackContador <= 0)
            {
                Horizontal = Input.GetAxis("Horizontal");
                Rigidbody2D.velocity = new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
                isGrounded = Physics2D.OverlapCircle(Trans.position, .2f, elpiso);

                if (Input.GetButtonDown("Jump"))
                {
                    if (isGrounded)
                    {
                        Rigidbody2D.velocity = new Vector2(Rigidbody2D.velocity.x, JumpForce);
                    }
                }
                if (Input.GetKey(KeyCode.P) && Horizontal != 0.0f)
                {
                    Speed = 1.9f;
                    animador.SetBool("Caminar", false);
                    animador.SetBool("Running", true);

                }
                else
                {
                    animador.SetBool("Running", false);
                    Speed = 1.1f;
                }

                if (Rigidbody2D.velocity.x < 0)
                {
                    sprite.flipX = true;

                }
                else if (Rigidbody2D.velocity.x > 0)
                {
                    sprite.flipX = false;
                }

                if (Input.GetKey(KeyCode.E) && Time.time>LastSHoot+.7f)
                {
                    StartCoroutine(AttackAndShoot());
                    LastSHoot = Time.time;
                }
            }
            else
            {
                KnockBackContador -= Time.deltaTime;
                if (!sprite.flipX)
                {
                    Rigidbody2D.velocity = new Vector2(-KnockBackFuerza, Rigidbody2D.velocity.y);
                }
                else
                {
                    Rigidbody2D.velocity = new Vector2(KnockBackFuerza, Rigidbody2D.velocity.y);
                }
            }
        }  
    }

    public void KnocckBack()
    {
        KnockBackContador = KnockBackLongitud;
        Rigidbody2D.velocity = new Vector2(0f, KnockBackFuerza);
    }

    public void DesactivarInput()
    {
        SigueVivo = false;
    }

    public void Shoot()
    {
        if (sprite.flipX)
        {
            direcion = Vector3.left;
        }
        else if(!sprite.flipX)
        {

            direcion = Vector3.right;
        }
        GameObject bullet=Instantiate(bala, transform.position+direcion*1.2f, Quaternion.identity);
        bullet.GetComponent<BulletScript>().SetDireccion(direcion);
    }

    private IEnumerator AttackAndShoot()
    {
        // Activa la animación de ataque
        animador.SetTrigger("Ataque"); // Asegúrate de tener un trigger en tu Animator

        yield return new WaitForSeconds(tiempoPorAnimacion);

        Shoot();
    }
}
