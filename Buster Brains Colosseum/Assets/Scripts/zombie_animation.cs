using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_animation : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Vector3 localVelocity;

    float oldXPos;

    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        oldXPos = transform.position.x;
    }
	
	// Update is called once per frame
	void Update () {

       
        float xPos = transform.position.x;

        if(xPos > oldXPos)
        {
            spriteRenderer.flipX = false;
            // face right
        }
        else
        {
            spriteRenderer.flipX = true;
            // face left
        }
        oldXPos = xPos;

        localVelocity = transform.InverseTransformDirection(rigidbody2D.velocity);

        //if (localVelocity.x > 0)
        //{
        //    spriteRenderer.flipX = false;
        //}
        //if (localVelocity.x < 0)
        //{
        //    spriteRenderer.flipX = true;
        //}
    }
}
