using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {
	public Camera c;
	public GameObject target;
	// Use this for initialization
	void Start () {
		c = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		c.transform.position = target.transform.forward+ new Vector3(0,100,-50);
	}
}
