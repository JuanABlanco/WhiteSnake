using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPower : MonoBehaviour {

    float tiempo = 0.0f;
    EnemyController[] enemigos;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        enemigos = GameObject.FindObjectsOfType<EnemyController>();
        tiempo += 1;
    }

    public void Terremoto()
    {
        float entrada = tiempo;
        for(int i=0; i<enemigos.Length && tiempo - entrada < 5; i++)
        {
            if (Mathf.Abs((enemigos[i].transform.position - transform.position).sqrMagnitude) <= 200)
            {
                Debug.Log("General Pecueca!");
                enemigos[i].Die();
            }       
        }
    }
}
