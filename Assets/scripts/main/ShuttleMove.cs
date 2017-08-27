using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class ShuttleMove : MonoBehaviour{
        private float limit = 2.5f;
        private Vector3 _mousePosition;
        private double _dist;

        void FixedUpdate(){
            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            _dist = Math.Sqrt(Math.Pow(_mousePosition.x - transform.position.x, 2) +
                              Math.Pow(_mousePosition.y - transform.position.y, 2));

            float koef = (float) _dist;
            if (_dist > limit){
                koef = limit * (limit / koef);
            }
            transform.position = Vector2.Lerp(transform.position, _mousePosition, koef / 100);
        }
    }
}