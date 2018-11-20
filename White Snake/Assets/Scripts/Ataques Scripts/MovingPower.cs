using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;


public class MovingPower : MonoBehaviour {

    public static MovingPower sharedInstance;
    float position;
    Timer timer;
    int tiempo = 0;
    EnemyController[] enemigos;
    ArrayList NBEnemy = new ArrayList();

    void Awake()
    {
        MovingPower.sharedInstance = this;
    }
    // Use this for initialization
    void Start () {
        position = Input.acceleration.x + Input.acceleration.y;
        

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
        timer.Interval = 2000;
        timer.Elapsed += Timer_Elapsed;
        timer.AutoReset = true;
        timer.Enabled = true;

        CheckEnemy();

        foreach (EnemyController ene in NBEnemy)
        {
            if(ene != null)
            {
                ene.Dañado((int)(Mathf.Abs(position - posi)));
                
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3, ForceMode2D.Impulse);
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 6, ForceMode2D.Impulse);
                ene.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 3, ForceMode2D.Impulse);
            }
            

        }
        if (tiempo > 3)
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
