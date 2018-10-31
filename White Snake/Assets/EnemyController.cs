using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public float maxSpeed = 7f; //Velocidad max
    public float speed = 12f; //Velocidad
    
        

    private Rigidbody2D rb2d;

    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();

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

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "Espada")
        {
            Destroy(gameObject, 0.1f);

        } else if (col.gameObject.tag == "Player")
        {

            // col.SendMessage("EnemyKnockBack", this.transform.position.x);

            // col.SendMessage("QuitarVida");

            PlayerController.sharedInstance.EnemyKnockBack(this.transform.position.x);
            PlayerController.sharedInstance.QuitarVida();
            

        }





    }

  




}
