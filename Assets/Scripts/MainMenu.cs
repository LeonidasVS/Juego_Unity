using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string primeraEscena;
    // Start is called before the first frame update
    public void StartGame()
    {
        SceneManager.LoadScene(primeraEscena);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
