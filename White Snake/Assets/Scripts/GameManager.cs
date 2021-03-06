﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public Text contador;
    public Button mic;
    public Button terremoto;
    public static GameManager sharedInstance;
    int enemigosMuertos;
    int enemigosVivos;
    EnemyController[] enemigos;
	// Use this for initialization
	void Start () {
        enemigos = GameObject.FindObjectsOfType<EnemyController>();
        enemigosVivos = enemigos.Length;
        GameManager.sharedInstance = this;
	}
	
	// Update is called once per frame
	void Update () {
        enemigos = GameObject.FindObjectsOfType<EnemyController>();
        if(enemigosVivos - enemigos.Length != 0 && contador != null)
        {
            ContarMuertos();
            enemigosVivos = enemigos.Length;
        }
        if(SceneManager.GetActiveScene().name == "Boss_Act_1" && enemigos.Length == 0)
        {
            SceneManager.LoadScene("Creditos");
        }
    }

    void OnTriggerEnter2D (Collider2D cuerpo)
    {
        if (cuerpo.tag == "Player")
        {
            SceneManager.LoadScene("Boss_Act_1");
        }
    }

    void ContarMuertos()
    {
        //if (!MovingPower.sharedInstance.isActiveAndEnabled && !PushPower.sharedInstance.isActiveAndEnabled) {
        if (enemigosMuertos == 4)
        {
            this.terremoto.gameObject.SetActive(true);
            this.mic.gameObject.SetActive(true);
            enemigosMuertos = 0;
        }
        else
        {
            enemigosMuertos += 1;
        }
        this.contador.text = this.enemigosMuertos.ToString();
        Debug.Log(enemigosMuertos);

        //}
    }
}
