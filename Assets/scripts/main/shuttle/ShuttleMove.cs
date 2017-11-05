using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

namespace main{
    public class ShuttleMove : MonoBehaviour{
        private float _limit = 2.5f;
        private Vector3 _mousePosition;
        private double _dist;
        private GameObject shuttlePositiontion;

        private void Start(){
            shuttlePositiontion = GameObject.Find("shuttlePositiontion");
        }

        void FixedUpdate(){
////            _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            _mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2,
//                Input.mousePosition.y - Screen.height / 2);
////            _dist = Math.Sqrt(Math.Pow(_mousePosition.x - transform.position.x, 2) +
////                              Math.Pow(_mousePosition.y - transform.position.y, 2));
//            _dist = distance(_mousePosition.x, transform.position.x, _mousePosition.y, transform.position.y);
//
//            float koef = (float) _dist;
//            if (_dist > _limit){
//                koef = _limit * (_limit / koef);
//            }
//            //_shuttle.transform.position =  transform.position;
//            var shuttleMagnitude = _shuttle.transform.position.magnitude;
//            var defMagnitude = transform.position.magnitude;
//            var diff = distance(_shuttle.transform.position.x, transform.position.x, _shuttle.transform.position.y,
//                transform.position.y);
//            var koefMagnitude =
//            if (diff != 0){
//                transform.position = Vector2.Lerp(transform.position, _mousePosition, koef / (300 * (1 + diff)));
//            _shuttle.transform.position = Vector2.Lerp(_shuttle.transform.position, transform.position, (float) _dist / 200);
//            } else{
            // transform.position = Vector2.Lerp(transform.position, _mousePosition, koef / 300);
//            }
            // Debug.Log(transform.position.magnitude + " - magnitude pos | " + _shuttle.transform.position.magnitude + " - shutle magnitude" );
            //transform.position = Vector2.Lerp(transform.position, _shuttle.transform.position, 1 /*, koef / 600*/);
        }

        private float distance(float x0, float x1, float y0, float y1){
            return (float) Math.Sqrt(Math.Pow(x0 - x1, 2) +
                                     Math.Pow(y0 - y1, 2));
        }
    }
}