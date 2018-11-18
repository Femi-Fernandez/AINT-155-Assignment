using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardObject : MonoBehaviour {
    public Transform target;
    public float speed = 5.0f;
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.FindGameObjectWithTag("Player");
        target = go.transform;
    }
	
	// Update is called once per frame
	void Update () {
        if (target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * 0.01f);
        }
	}
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
    }
}
