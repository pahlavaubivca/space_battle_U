using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	private void OnCollisionEnter(Collision collision){
		if (collision.gameObject.name == "bullet"){
			Debug.Log("collision");
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
