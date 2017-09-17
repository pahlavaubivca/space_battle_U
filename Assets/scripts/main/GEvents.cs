using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GEvents : MonoBehaviour{
//	public GameObject other;
//	public Camera cam = other.GetComponent<Camera>();
    private int count = 0;
    void Update(){
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("i was clicked - " + count);
            count++;
        }
    }
//	void OnMouseDown(){ // efficient if need catch event on object, if need catch event everywere use Update method
//		Debug.Log("click");
//	}
//
//	public void OnPointerClick(PointerEventData eventData){
//		Debug.Log("I was clicked");
//	}
//
//	public void OnPointerDown(PointerEventData eventData){
//		Debug.Log("down");
//	}
//	public void someClick(){
//		Debug.Log("asdfasdfas");
//	}
}