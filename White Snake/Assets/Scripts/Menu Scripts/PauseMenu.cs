using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    /*
     * Nombre del metodo: Pause
     * Funcion: Pausa el tiempo del juego
     * Parametros: Ninguno 
     */

    public void Pause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
    }

    /*
     * Nombre del metodo: Resume
     * Funcion: Reanuda el tiempo del juego
     * Parametros: Ninguno 
     */

    public void Resume()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
    }

    /*
     * Nombre del metodo: MainMenu
     * Funcion: Regresa al jugador al menu principal
     * Parametros: Ninguno 
     */

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}

