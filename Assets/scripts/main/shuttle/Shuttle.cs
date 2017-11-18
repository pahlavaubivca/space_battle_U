using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Shuttle : MonoBehaviour{
        private Fire _fire;
        private float _limit = 120f;
        private float maxSpeed = 120;
        private float speedreduction = 11.5f;
        private Vector3 _mousePosition;
        private double _dist;
        private GameObject shuttlePosition;
        private Rigidbody2D _rigidBody;

        void Start(){
            _fire = this.GetComponent<Fire>();
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }

        private void Update(){
            if (Input.GetMouseButtonDown(0)){
                _fire.CalculateStart();
            }
        }

        private void FixedUpdate(){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) *
                Mathf.Rad2Deg);

            _mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2,
                Input.mousePosition.y - Screen.height / 2);
            _dist = distance(_mousePosition.x, transform.position.x, _mousePosition.y, transform.position.y);
            float koef = (float) _dist;
            if (_dist > _limit){
                koef = _limit / koef;
            }
            if (_rigidBody.velocity.magnitude > maxSpeed){
                _rigidBody.velocity = _rigidBody.velocity.normalized * maxSpeed;
            } else{
                Debug.Log(_rigidBody.velocity);
                _rigidBody.AddForce(_mousePosition * koef);
            }
            
            
        }

        private float distance(float x0, float x1, float y0, float y1){
            return (float) Math.Sqrt(Math.Pow(x0 - x1, 2) +
                                     Math.Pow(y0 - y1, 2));
        }
    }
}