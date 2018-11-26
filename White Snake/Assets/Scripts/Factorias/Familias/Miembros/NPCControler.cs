using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPCControler : Personaje {
    public Text ConBar;
    public Image Panel;
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
            this.Panel.color =new Color(255f, 255f, 255f, 0.5f);
            this.ConBar.text = this.name + ": " + texto;
        }else
        {
            this.Panel.color = new Color(0f,0f,0f,0f);
            this.ConBar.text = "";
        }
    }


}
