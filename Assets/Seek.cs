using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seek : MonoBehaviour {
	float forward=1000f;
	Boid b;
	Vector3 target;
	// Use this for initialization
	void Start () {
		target = transform.position + new Vector3 (0,0,forward);
		b = GetComponent<Boid> ();
	}

	public Vector3 Calculate () {
		Vector3 toTarget = target - transform.position;
		toTarget.Normalize ();
		Vector3 desired = toTarget * b.maxSpeed;
		return desired - b.velocity;
	}
}
