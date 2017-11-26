using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace main{
    public class Shuttle : MonoBehaviour{
        private Fire _fire;
        private float _limit = 100f;
        private float maxSpeed = 120f;
        private float speedreduction = 11.5f;

        private Base _base;

//        private Rigidbody2D _rigidBody;
        void Start(){
            _fire = this.GetComponent<Fire>();
//            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
            _base = gameObject.AddComponent<Base>();
        }

        private void Update(){
            if (Input.GetMouseButtonDown(0)){
                _fire.CalculateStart();
            }
        }

        private void FixedUpdate(){
            Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePositionRelateScreen = new Vector2(Input.mousePosition.x - Screen.width / 2, Input.mousePosition.y - Screen.height / 2);
            _base.AngleToPoint(mousePosition, 0.2f);
            _base.MoveGameObject(mousePositionRelateScreen, maxSpeed, _limit);
        }
    }
}