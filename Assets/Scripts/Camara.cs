using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camara : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform target;

    public Transform Estilo1,Estilo2;
    private float LastPosicionX;
    public float maxAlto,minAlto;
    void Start()
    {
        LastPosicionX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position=new Vector3(target.position.x,Mathf.Clamp(target.position.y,minAlto,maxAlto),transform.position.z);

        float movimientEnX = transform.position.x - LastPosicionX;
        Estilo2.position = Estilo2.position + new Vector3(movimientEnX, 0f, 0f);

        Estilo1.position += new Vector3(movimientEnX * .5f,0f,0f);

        LastPosicionX = transform.position.x;
    }
}
