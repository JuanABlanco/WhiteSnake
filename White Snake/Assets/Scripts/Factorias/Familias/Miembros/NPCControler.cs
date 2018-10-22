using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControler : Personaje {
    public Text ConBar;

	void Awake()
    {
        this.maxLife = 10000;
        this.currentLife = this.maxLife;
    }

    //Mostrar mensaje personalizado en la barra de conversaciones de la camara
    protected void Say(string texto)
    {
        if (texto != null)
        {
            this.ConBar.text = this.name + ": " + texto;
        }else
        {
            this.ConBar.text = "";
        }
    }


}
