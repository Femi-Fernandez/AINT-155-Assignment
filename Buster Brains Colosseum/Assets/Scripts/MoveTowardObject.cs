using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardObject : MonoBehaviour {
    public Transform target;
    public float maxspeed = 150.0f;
    public float acceleration = 1.0f;


    private float currentSpeed = 0.0f;

    // Use this for initialization
    void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }
	
	// Update is called once per frame
	void Update () {
        currentSpeed += acceleration;
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, currentSpeed * 0.1f);

            

            if (currentSpeed > maxspeed)
            {
                currentSpeed = maxspeed;
            }
        }
	}
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
