using UnityEngine;
using UnityEngine.SceneManagement;


public class MenuDePausa : MonoBehaviour
{
    public static MenuDePausa instance;
    public string menuPrincipal;
    public GameObject pausaScreen;
    public bool estaPausado;

    // Start is called before the first frame update
    void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("MenuDePausa") && !SalirDelNivel.instance.tocoPointFinalizador)
        {
            JuegoEnPausa();
        }
        
    }

    public void JuegoEnPausa()
    {
        if (estaPausado)
        {
            estaPausado = false;
            pausaScreen.SetActive(false);
            Time.timeScale = 1f;
            
        }
        else
        {
            estaPausado = true;
            pausaScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void MenuPrincipal()
    {
        SceneManager.LoadScene(menuPrincipal);
        Time.timeScale = 1f;
    }
}
