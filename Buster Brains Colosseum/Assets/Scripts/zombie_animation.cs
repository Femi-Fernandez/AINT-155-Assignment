using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombie_animation : MonoBehaviour {

    Rigidbody2D rigidbody2D;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Vector3 localVelocity;
    // Use this for initialization
    void Start () {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }
	
	// Update is called once per frame
	void Update () {

        localVelocity = transform.InverseTransformDirection(rigidbody2D.velocity);

        if (localVelocity.x > 0)
        {
            spriteRenderer.flipX = false;
        }
        if (localVelocity.x < 0)
        {
            spriteRenderer.flipX = true;
        }
    }
}
