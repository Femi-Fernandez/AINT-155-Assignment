using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombiedamage : MonoBehaviour {

    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        other.transform.SendMessage("TakeDamage", damage, SendMessageOptions.DontRequireReceiver);
        
    }

    private void Die()
    {
        Destroy(gameObject);
    }
   
}
