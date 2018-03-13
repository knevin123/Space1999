using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OffsetPursue : MonoBehaviour {
	public GameObject leader;
	Boid b;
	Vector3 offset=new Vector3(20,0,20);
	float slowingDistance=10;
	// Use this for initialization
	void Start () {
		b = GetComponent<Boid> ();
		leader = GameObject.FindGameObjectWithTag ("Leader");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public Vector3 Calculate()
	{
		Vector3 worldTarget = leader.transform.TransformPoint (offset);
		float dist = (worldTarget-transform.position).magnitude;
		float time = dist / b.maxSpeed;
		Vector3 pursuePos = leader.transform.position + (time * leader.transform.forward);
		Vector3 toTarget = pursuePos - transform.position;
		float pursue = toTarget.magnitude;
		float ramped = b.maxSpeed * (dist / slowingDistance);
		float clamped = Mathf.Min (ramped, b.maxSpeed);
		Vector3 desired = clamped * (toTarget / dist);
		return desired - b.velocity;
	}
}
