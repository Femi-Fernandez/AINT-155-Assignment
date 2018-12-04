using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class invincibleOnHit : MonoBehaviour {


    private bool invincible = false;
    public float invincibility_timer = 2.0f;
    Collider2D player_collider;
    private float i = 0.0f;


    // Use this for initialization
    void Start () {
        player_collider = GetComponent<Collider2D>();
    }

    private IEnumerator invincible_timer()
    {
        yield return new WaitForSeconds(invincibility_timer);
        player_collider.enabled = !player_collider.enabled;
        invincible = false;

    }

    public void Onhit()
    {
   
        if (invincible == false)
        {
            invincible = true;
            player_collider.enabled = !player_collider.enabled;

            StartCoroutine(invincible_timer());
        }

    }
}
