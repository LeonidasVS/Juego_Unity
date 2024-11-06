using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaOpciones : MonoBehaviour
{
    public ControladorOpciones controladorOpciones;

    // Start is called before the first frame update
    void Start()
    {
        controladorOpciones=GameObject.FindGameObjectWithTag("Opciones").GetComponent<ControladorOpciones>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            mostrarOpciones();
        }
    }
    public void mostrarOpciones()
    {
        controladorOpciones.pantallaOpciones.SetActive(true);
    }
}
