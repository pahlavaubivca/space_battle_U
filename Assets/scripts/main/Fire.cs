using System;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        private int count = 0;

        void Update(){
            if (Input.GetMouseButtonDown(0)){
                Debug.Log("click - " + count);
                count++;
            } 
        }
        void FixedUpdate(){
            
        }
    }
}