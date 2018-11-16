using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Personaje {

    //Variables

    public float maxSpeed = 15f; 
    public float speed = 2f; 
    public bool grounded;
    public float jumpPower = 27f;
    public static PlayerController sharedInstance;
    public GameObject lifeBar;
    public List<GameObject> hearts;

    private Rigidbody2D rb2d; 
    private Animator anim;
    private SpriteRenderer spr;
    private bool jump;
    private bool movement = true;
    private bool estoyAtacando = false;




    void Awake()
    {
        this.maxLife = 3;
        this.origen = transform.position;
        PlayerController.sharedInstance = this;
    }
    // Use this for initialization
    void Start () {

        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
        for (int i = 0; i < this.maxLife; i++)
        {
            AgregarCorazon();
        }
    }
	
	// Update is called once per frame
	void Update () {

        anim.SetFloat("Speed", Mathf.Abs(rb2d.velocity.x));
        anim.SetBool("Grounded", grounded);

        //saltar
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetAxisMobile("Vertical") !=0 && grounded)
        {

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

            //float v = Input.GetAxisMobile("Vertical");
            Jump();
        }



        //Atacar
        if (!estoyAtacando && Input.GetKeyDown(KeyCode.LeftControl) )
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

    /// <summary>
    /// Esta funcion se encarga del salto del personaje
    /// </summary>
    public void Jump()
    {
        if (this.grounded)
        {
            rb2d.AddForce(Vector2.up * jumpPower* 2, ForceMode2D.Impulse);
            jump = false;
        }
    }

    /// <summary>
    /// Esta funcion se encarga de recolocar al personaje en su posicion inicial cuando no es visible para la camara 
    /// </summary>
    void OnBecameInvisible()
    {
        transform.position = this.origen;
        int limite = this.maxLife - this.currentLife;
        for (int i = 0; i < limite; i++)
        {
            AgregarCorazon();
        }
    }

    /// <summary>
    /// Metodo que se encarga de restarle vida al personaje 
    /// </summary>
    public void QuitarVida()
    {
        PerderCorazon();
        if (this.currentLife == 0)
        {
            DropLoot();
            transform.position = this.origen;
            for(int i = 0; i < this.maxLife; i++)
            {
                AgregarCorazon();
            }
        }
    }

    /// <summary>
    /// Este metodo se encarga de toda la logica de la animacion cuando el personaje recibe daño
    /// </summary>
    /// <param name="enemyPosX"> Posicion en el eje X de la funte del daño</param>
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
    /// <summary>
    /// Esta funcion se encarga de permitir el movimiento
    /// </summary>
    void EnableMovement()
    {
        movement = true;
        spr.color = Color.white;
    }

    /// <summary>
    /// Este metodo se encarga de activar la animacion de ataque
    /// </summary>
    public void Ataque()
    {
        if (!estoyAtacando && anim.GetCurrentAnimatorStateInfo(0).fullPathHash != Animator.StringToHash("Base Layer.Player_Attack"))
        {
            anim.SetTrigger("Ataque");
            
        }
        
    }

    /*
     *  La siguiente seccion de codigo se encarga del control de la barra de vida 
     *
     */


     ///<summary>Este metodo instancia un corazon en la barra de vida del HUD y aumentar la vida del jugador</summary> 
    public void AgregarCorazon()
    {
        GameObject corazon = Instantiate(this.lifeBar);
        this.hearts.Add(corazon);
        corazon.transform.name = "Heart";
        Debug.Log("Naci puto");
        

        corazon.transform.parent = this.lifeBar.transform.parent;
        corazon.transform.position = this.lifeBar.transform.position + new Vector3(-1.5f*this.hearts.Count, 0f, 0f);
        corazon.transform.localScale = new Vector3(10f, 10f, 10f);

        this.currentLife += 1;
        
    }

    /// <summary>Este metodo elimina un corazon de la barra de vida del HUD y disminuye la vida del jugador</summary>
    public void PerderCorazon()
    {
        Destroy((GameObject)this.hearts[this.hearts.Count-1]);
        this.hearts.RemoveAt(this.hearts.Count - 1);
        this.currentLife -= 1;
    }

}
