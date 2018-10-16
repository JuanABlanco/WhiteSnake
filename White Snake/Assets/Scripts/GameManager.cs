using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D (Collider2D cuerpo)
    {
        if (cuerpo.tag == "Player")
        {
            SceneManager.LoadScene("Boss_Act_1");
        }
    }
}
