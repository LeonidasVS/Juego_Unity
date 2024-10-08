using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCheckPoint : MonoBehaviour
{
    public static ControladorCheckPoint instance;
    public Checkpoint1[] checkPoint;
    public Vector3 spanwPoint;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        checkPoint = FindObjectsOfType<Checkpoint1>();
        spanwPoint = PlayerMovimiento.instancia.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DesactivarCheckPoint()
    {
        for(int i = 0; i < checkPoint.Length; i++)
        {
            checkPoint[i].ResetCheckPoint();
        }
    }

    public void SetSpawnPoint(Vector3 nuevoSpanwPoint)
    {
        spanwPoint = nuevoSpanwPoint;
    }
}
