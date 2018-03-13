using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boid : MonoBehaviour {
	public Vector3 force;
	public Vector3 velocity;
	public Vector3 acceleration;
	public float mass = 1;
	public float maxSpeed = 10;
	public Seek s;
	Rigidbody rb;
	public OffsetPursue o;
	public bool leader;
	// Use this for initialization
	void Start () {
		//select whether leader or follower to activate behaviour
		if (leader == true) {
			s = GetComponent<Seek> ();
		} else {
			o = GetComponent<OffsetPursue> ();
		}
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if (leader == true) {
			force = s.Calculate ();
		} else {
			force = o.Calculate ();
		}
		acceleration = force / mass;
		velocity += acceleration * Time.deltaTime;
		velocity = Vector3.ClampMagnitude (velocity, maxSpeed);
		velocity *= 0.99f;
		transform.position += velocity * Time.deltaTime;

		if (velocity.magnitude > float.Epsilon) {
			transform.forward = velocity;
		}
	}
}
