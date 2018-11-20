using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class MovingPower : MonoBehaviour {

    Timer timer;
    int tiempo = 0;
    EnemyController[] enemigos;
    ArrayList NBEnemy = new ArrayList();

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CheckEnemy();
    }

    void CheckEnemy()
    {
        enemigos = GameObject.FindObjectsOfType<EnemyController>();
        for (int i = 0; i < enemigos.Length; i++)
        {
            if (Mathf.Abs((enemigos[i].transform.position - transform.position).sqrMagnitude) <= 200)
            {
                NBEnemy.Add(enemigos[i]);
            }
        }
    }

    public void Terremoto()
    {
        float posi = Input.acceleration.x + Input.acceleration.y;
        tiempo = 0;
        timer = new Timer();
        timer.Interval = 1000;
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true;
        timer.Enabled = true;

        CheckEnemy();

        foreach (EnemyController ene in NBEnemy)
        {
            if(ene != null)
            {
                ene.Dañado((int)Mathf.Round(((Input.acceleration.x + Input.acceleration.y)-posi) / 5));
                Debug.Log(((Input.acceleration.x + Input.acceleration.y) - posi) / 5);
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3, ForceMode2D.Impulse);
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 6, ForceMode2D.Impulse);
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3, ForceMode2D.Impulse);
            }
            

        }
        if (tiempo > 5)
        {
            timer.Enabled = false;
            timer.AutoReset = false;
            timer.Elapsed -= Timer_Elapsed;
        }
    }

    private void Timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        tiempo += 1;
        //Debug.Log(tiempo);
        throw new System.NotImplementedException();
    }
}
