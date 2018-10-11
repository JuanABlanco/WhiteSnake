using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed = 10f;

    public float speed = 2f;

    private Rigidbody2D rb2d;

	// Use this for initialization
	void Start () {

        rb2d = GetComponent<Rigidbody2D>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {

        float h = Input.GetAxis("Horizontal");

        rb2d.AddForce(Vector2.right * h * speed);

        if (rb2d.velocity.x > maxSpeed)
        {
            rb2d.velocity = new Vector2(maxSpeed, rb2d.velocity.y);
        }

        if (rb2d.velocity.x < -maxSpeed)
        {
            rb2d.velocity = new Vector2(-maxSpeed, rb2d.velocity.y);
        }

        Debug.Log(rb2d.velocity.x);

    }
}
