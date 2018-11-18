using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow2D : MonoBehaviour {

    public Transform target;
    public float smoothing = 5.0f;

	// Update is called once per frame
	void Update () {
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -25);
        transform.position = Vector3.Lerp(transform.position, newPos, (smoothing * .001f));
	}
}
