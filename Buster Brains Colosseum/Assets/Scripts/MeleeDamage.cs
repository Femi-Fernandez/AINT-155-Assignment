using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeDamage : MonoBehaviour {

    public float moveSpeed = 0.0f;
    public int damage = 1;
    public float swingtime = 0.1f;
    // Use this for initialization
    void Start()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * moveSpeed);
        StartCoroutine(meleeDie());
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        
    }


    private IEnumerator meleeDie()
    {
        yield return new WaitForSeconds(swingtime);
        Die();
    }

    private void OnBecameInvisible()
    {
        Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
