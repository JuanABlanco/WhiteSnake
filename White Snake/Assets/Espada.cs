﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : Objeto {

	// Use this for initialization
	void Start () {
        this.drop = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            Debug.Log("Estoy atacando a un enemigo");
        }
    }
}
