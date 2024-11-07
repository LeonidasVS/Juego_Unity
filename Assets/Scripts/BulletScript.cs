using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Rigidbody2D rigi;
    public float speed;
    private Vector3 Direccion;
    private SpriteRenderer sprite;
    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        rigi.velocity = Direccion*speed;

        if (rigi.velocity.x < 0)
        {
           sprite.flipX=true;
        }
    }

    public void SetDireccion(Vector3 direccion)
    {
        Direccion = direccion;
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
