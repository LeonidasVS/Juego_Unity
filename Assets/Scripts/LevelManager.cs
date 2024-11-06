using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    // Start is called before the first frame update

    public float waitRespawn;
    public string menuPrincipal;
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

    public void TerminarNivel()
    {
        StartCoroutine(TerminarLevel());
    }

    public IEnumerator TerminarLevel()
    {
        PlayerMovimiento.instancia.finalizoNivel = true;
        Camara.instance.pararCamara = true;

        CanvasControler.instance.NivelCompletadoText.SetActive(true);
        yield return new WaitForSeconds(2.5f);

        CanvasControler.instance.FadePantallaFinal();
        yield return new WaitForSeconds((15f / CanvasControler.instance.fadeSpeed) + .25f);
        SceneManager.LoadScene(menuPrincipal);
    }
}

