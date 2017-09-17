using System;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.EventSystems;

namespace main{
    public class Fire : MonoBehaviour, IPointerClickHandler {
        private int count = 0;

        void Update(){
           
        }
//        void OnMouseDown(){
//            Debug.Log("click");
//        }

        public void OnPointerClick(PointerEventData eventData){
            
//            Debug.Log("I was clicked " +  count);
//            count++;
        }

//        public void OnPointerDown(PointerEventData eventData){
//            Debug.Log("down - " +  +  count);
//            count++;
//        }

//        void OnMouseOver(){ // work only on this gameObject
//            if (Input.GetMouseButtonDown(0)){
//                Debug.Log("asfdasd");
//            }
//        }
    }
}