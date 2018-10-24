using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objeto : MonoBehaviour {
    public bool drop = true;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            GetLooted();
        }
    }

    //Metodo que se encarga de ayudar al jugador a lootear el objeto
    void GetLooted()
    {
        PlayerController.sharedInstance.invetario.Add(gameObject);
        this.gameObject.SetActive(false);
        this.transform.SetParent(PlayerController.sharedInstance.transform);
    }

}
