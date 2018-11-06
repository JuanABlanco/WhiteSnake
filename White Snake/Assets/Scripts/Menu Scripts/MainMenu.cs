using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    /*
     * Este Script maneja el comportamiento del menu principal del juego
     */

    /*
     * Nombre del metodo: Play
     * Funcion: Actualmente lo unico que hace es iniciar la siguiente escena del juego, pero en el futuro debera ser capaz de cargar la partida seleccionada por el jugador.
     * Parametros: Ninguno 
     */

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    /*
     * Nombre del metodo: Quit
     * Funcion: Cierra el juego
     * Parametros: Ninguno 
     */

    public void Quit()
    {
        Application.Quit();
    }
}
