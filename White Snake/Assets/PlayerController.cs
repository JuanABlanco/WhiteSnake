using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Personaje {

    //Variables

    public float maxSpeed = 15f; 
    public float speed = 2f; 
    public bool grounded;
    public float jumpPower = 25f; 

    private Rigidbody2D rb2d; 
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool movement = true;
    private bool estoyAtacando = false;

    void Awake()
    {
        this.maxLife = 3;
        this.currentLife = this.maxLife;
        this.origen = transform.position;
    }
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        //saltar
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded){

            jump = true;

        }

    }

private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        if (!movement)
        {
            h = 0;
        }

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

        //Debug.Log(rb2d.velocity.x);



        //Atacar
        if (!estoyAtacando && Input.GetKeyDown(KeyCode.LeftControl))
        {
            Ataque();
            
        }

        if (anim.GetCurrentAnimatorStateInfo(1).fullPathHash != Animator.StringToHash("Base Layer.Player_Attack") && estoyAtacando && !Input.GetKey(KeyCode.LeftControl)) {
            estoyAtacando = false;
        }

        if (anim.GetCurrentAnimatorStateInfo(1).fullPathHash == Animator.StringToHash("Base Layer.Player_Attack") && !estoyAtacando )
        {
            estoyAtacando = true;
        }

    }

    //Respawn del personaje
    void OnBecameInvisible()
    {
        transform.position = this.origen;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        
        if (col.tag == "Enemy" )
        {
            Debug.Log("ke");
            this.currentLife = this.currentLife - 1;
            if (this.currentLife == 0)
            {
                DropLoot();
                transform.position = this.origen;
                this.currentLife = this.maxLife;
            }
        }
    }

    //Ataque del enemigo
    public void EnemyKnockBack(float enemyPosX)
    {
        jump = true;
        float side = Mathf.Sign(enemyPosX - transform.position.x);
        
        rb2d.AddForce(Vector2.left * side * (jumpPower - 10 ) , ForceMode2D.Impulse);

        movement = false;

        Invoke("EnableMovement", 0.5f);

        Color color = new Color(255/255f, 106/255f, 0f);

        spr.color = color;
    } 

    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    //Atacar
    void Ataque()
    {
        if (!estoyAtacando && anim.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Player_Attack"))
        {
            anim.SetTrigger("Ataque");
            
        }
        
    }
}
