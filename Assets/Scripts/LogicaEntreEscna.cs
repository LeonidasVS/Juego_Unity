using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEntreEscna : MonoBehaviour
{
    private void Awake()
    {
        var noDestruirEntreEscenas = FindObjectsOfType<LogicaEntreEscna>();
        if (noDestruirEntreEscenas.Length>1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
