using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    // Start is called before the first frame update

    public float waitRespawn;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespownPlayer()
    {
        PlayerMovimiento.instancia.sprite.flipX = false;
        StartCoroutine(RespawnCo());
    }

    IEnumerator RespawnCo()
    {
        PlayerMovimiento.instancia.gameObject.SetActive(false);
        yield return new WaitForSeconds(waitRespawn);
        PlayerMovimiento.instancia.gameObject.SetActive(true);

        PlayerMovimiento.instancia.transform.position = ControladorCheckPoint.instance.spanwPoint;
    }
}
