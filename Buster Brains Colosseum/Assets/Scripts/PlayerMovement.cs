using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5.0f;
    Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");


        animator.SetFloat("Speed", Mathf.Abs(x));

        rigidbody2D.velocity = new Vector2(x, y) * speed;
        rigidbody2D.angularVelocity = 0.0f;


        if (rigidbody2D.velocity.x >= 0 )
        {
            spriteRenderer.flipX = false;
        }
        else
        {
            spriteRenderer.flipX = true;
        }

        if (rigidbody2D.velocity.y > 0)
        {
            animator.SetBool("Move_up", true);
        }
        else
        {
            animator.SetBool("Move_up", false);
        }
        if (rigidbody2D.velocity.y < 0)
        {
            animator.SetBool("Move_down", true);
        }
        else
        {
            animator.SetBool("Move_down", false);
        }
    }
}
