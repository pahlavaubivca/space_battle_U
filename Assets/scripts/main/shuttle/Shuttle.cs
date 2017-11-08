using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Shuttle : MonoBehaviour{
        public bool ThisIsShuttle = true;
        private Fire _fire;
        private float _limit = 0.5f;
        private float maxSpeed = 0.01f;
        private Vector3 _mousePosition;
        private double _dist;
        private GameObject shuttlePosition;
        private Rigidbody2D _rigidBody;

        void Start(){
            _fire = this.GetComponent<Fire>();
            shuttlePosition = GameObject.Find("shuttlePosition");
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
//            _rigidBody.drag = 0.0001f;
        }

        void Update(){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) *
                Mathf.Rad2Deg);
//            Shuttle asd = gameObject.GetComponent<Shuttle>();
//            asd.GetComponent<Rigidbody2D>().transform.position = new Vector3(0,0,0);
            //  transform.transform.position = new Vector3(transform.position.x,transform.position.y,0);

            if (Input.GetMouseButtonDown(0)){
                _fire.CalculateStart();
            }
        }

        private void FixedUpdate(){
            _mousePosition = new Vector2(Input.mousePosition.x - Screen.width / 2,
                Input.mousePosition.y - Screen.height / 2);
            _dist = distance(_mousePosition.x, transform.position.x, _mousePosition.y, transform.position.y);
            float koef = (float) _dist;
            if (_dist > _limit){
                koef = _limit * (_limit / koef);
            }
            //transform.position = Vector2.Lerp(transform.position, _mousePosition, koef / 300);
//            if (_rigidBody.velocity.magnitude > _limit){
//                _rigidBody.velocity = _rigidBody.velocity.normalized * _limit;
//            } else{
//                _rigidBody.AddForce(_mousePosition * koef / 30);
//                _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _limit);
//            }

            _rigidBody.AddForce(_mousePosition * koef / 300, ForceMode2D.Force);
            if (Mathf.Abs(_rigidBody.velocity.x) > 0.01f){
                Debug.Log("x limit - " + _rigidBody.velocity.x);
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x < 0 ? maxSpeed * -1 : maxSpeed, _rigidBody.velocity.y);
            }
            if (Mathf.Abs(_rigidBody.velocity.y) > 0.01f){
                _rigidBody.velocity = new Vector2(_rigidBody.velocity.x , _rigidBody.velocity.y < 0 ? maxSpeed * -1 : maxSpeed);
            }
//            if (Mathf.Abs(_rigidBody.velocity.x) + Mathf.Abs(_rigidBody.velocity.y) > 0.01f){
//                //_rigidBody.velocity = _rigidBody.velocity * koef / 300;
//                _rigidBody.velocity = new Vector2(transform.position.x < 0 ? maxSpeed * -1 : maxSpeed,
//                    transform.position.y < 0 ? maxSpeed * -1 : maxSpeed);
//                //_rigidBody.velocity = Vector3.Normalize(_rigidBody.velocity) * Mathf.Sqrt(0.001f);
//                Debug.Log("trying to normalize, magnitude - " + _rigidBody.velocity.magnitude);
//            } 

            //_rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, _limit);
//            Debug.Log(_rigidBody.velocity.magnitude);

            shuttlePosition.transform.position = transform.position;
        }

        private float distance(float x0, float x1, float y0, float y1){
            return (float) Math.Sqrt(Math.Pow(x0 - x1, 2) +
                                     Math.Pow(y0 - y1, 2));
        }
    }
}