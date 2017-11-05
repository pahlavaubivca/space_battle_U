using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Shuttle : MonoBehaviour{
        public bool ThisIsShuttle = true;
        private Fire _fire;
        private float _limit = 2.5f;
        private Vector3 _mousePosition;
        private double _dist;
        private GameObject shuttlePosition;
        private Rigidbody2D _bodyRigid;
        
        void Start(){
            _fire = this.GetComponent<Fire>();
            shuttlePosition = GameObject.Find("shuttlePosition");
            _bodyRigid = gameObject.GetComponent<Rigidbody2D>();
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
            transform.position = Vector2.Lerp(transform.position, _mousePosition, koef / 3000);
            // Debug.Log(_bodyRigid.velocity.magnitude);
//            if (_bodyRigid.velocity.x > 0.1f || _bodyRigid.velocity.y > 0.1f){
//                _bodyRigid.velocity = new Vector2(1f,1f);
//                Debug.Log(_bodyRigid.velocity.magnitude);
//            }
            shuttlePosition.transform.position = transform.position;
        }
        private float distance(float x0, float x1, float y0, float y1){
            return (float) Math.Sqrt(Math.Pow(x0 - x1, 2) +
                                     Math.Pow(y0 - y1, 2));
        }
    }
}