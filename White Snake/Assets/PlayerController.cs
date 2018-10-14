using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Personaje {

    //Variables

    public float maxSpeed = 15f; //Velocidad max
    public float speed = 2f; //Velocidad
    public bool grounded;
    public float jumpPower = 25f; //Fuerza de salto

    private Rigidbody2D rb2d; //Cuerpo rigido
    private Animator anim;
    private bool jump;

    void Awake()
    {
        this.maxLife = 3;
        this.currentLife = this.maxLife;
    }
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){

            jump = true;

        }

		
	}

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * h * speed);

        float limitedSpeed = Mathf.Clamp(rb2d.velocity.x, -maxSpeed, maxSpeed);
        rb2d.velocity = new Vector2(limitedSpeed, rb2d.velocity.y);

        //Direccion
        if (h > 0.1f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }

        if (h < -0.1f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }


        if (jump) { 
            rb2d.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            jump = false;
        }

        Debug.Log(rb2d.velocity.x);

    }

    void OnBecameInvisible()
    {
        transform.position = new Vector3(-8, 2, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("ke");
        if (col.tag == "Enemy")
        {

            this.currentLife = this.currentLife - 1;
            if (this.currentLife == 0)
            {
                DropLoot();
            }
        }
    }
}
