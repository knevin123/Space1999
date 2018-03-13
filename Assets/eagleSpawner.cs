using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eagleSpawner : MonoBehaviour {
	public float gap = 20;
	public float followers = 2;

	public GameObject prefab;
	// Use this for initialization
	void Start () {
		
	}
	void Awake(){
		//initialise target positions for the follower ships
		Vector3 targetpos=new Vector3(0,0,0);
		Vector3 targetpos2=new Vector3(0,0,0);
		for (int i = 0; i < followers; i++) {
			//make spawn positions for the followers
			targetpos = prefab.transform.position + new Vector3(gap*(i+1),0,-gap*(i+1));
			targetpos2 = prefab.transform.position + new Vector3(-gap*(i+1),0,-gap*(i+1));
			//instantiate followers, also include the prefab rotation 
			//to insure they are in the correct orientation
			Instantiate(prefab,targetpos,prefab.transform.rotation);
			Instantiate(prefab,targetpos2,prefab.transform.rotation);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
