using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint1 : MonoBehaviour
{
    public SpriteRenderer spriteR;
    public Sprite cpOn, cpOff;
    // Start is called before the first frame update

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ControladorCheckPoint.instance.DesactivarCheckPoint();
            spriteR.sprite = cpOn;
            ControladorCheckPoint.instance.SetSpawnPoint(transform.position);
        }
    }

    public void ResetCheckPoint()
    {
        spriteR.sprite = cpOff;
    }
}
