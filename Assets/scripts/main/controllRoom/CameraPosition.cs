using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPosition : MonoBehaviour{
	public GameObject shuttle;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate (){
		transform.position = new Vector3(shuttle.transform.position.x, shuttle.transform.position.y,-5);
	}

//	private void Update(){
//		transform.position = new Vector3(shuttle.transform.position.x, shuttle.transform.position.y,-5);
//	}
}
