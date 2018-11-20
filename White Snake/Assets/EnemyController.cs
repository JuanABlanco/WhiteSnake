using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Personaje {

    public float maxSpeed = 7f; //Velocidad max
    public float speed = 12f; //Velocidad
    
        

    private Rigidbody2D rb2d;

    void Awake()
    {
        if(gameObject.name == "Boss")
        {
            this.maxLife = 90;
        }
        else
        {
            this.maxLife = 3;
        }
    }
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        this.currentLife = this.maxLife;

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        rb2d.AddForce(Vector2.right * speed);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        if(rb2d.velocity.x > -0.01f && rb2d.velocity.x < 0.01f)
        {
            speed = -speed;
            rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
        }

        if (speed < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);

        } else if (speed > 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }

        

    }

    public void Dañado()
    {
        Color original = this.GetComponent<SpriteRenderer>().color;
        this.currentLife -= PlayerController.sharedInstance.currentDamage;
        this.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 106 / 255f, 0f);
        this.GetComponent<Rigidbody2D>().AddForce(-this.transform.position.normalized*10, ForceMode2D.Impulse);
        if (this.currentLife <= 0)
        {
            this.Die();
        }
        this.GetComponent<SpriteRenderer>().color = original;
    }

    public void Dañado(int daño)
    {
        if(daño > 0)
        { 
            //Color original = this.GetComponent<SpriteRenderer>().color;
            this.currentLife -= daño;
            this.GetComponent<SpriteRenderer>().color = new Color(255 / 255f, 106 / 255f, 0f);
            if (this.currentLife <= 0)
            {
                this.Die();
            }
            //this.GetComponent<SpriteRenderer>().color = original;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Espada")
        {

            Dañado();

        } else if (col.gameObject.tag == "Player")
        {

            // col.SendMessage("EnemyKnockBack", this.transform.position.x);

            // col.SendMessage("QuitarVida");

            PlayerController.sharedInstance.EnemyKnockBack(this.transform.position.x);
            PlayerController.sharedInstance.QuitarVida();
            

        }





    }

  




}
