using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DioController : NPCControler {

    public DioController sharedInstance;

    void Awake()
    {
        this.sharedInstance = this;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            Say("Cuidate el dulce mas adelante...");
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            Say(null);
        }
    }
}
