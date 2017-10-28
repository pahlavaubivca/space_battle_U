using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Shuttle : MonoBehaviour{
        public bool ThisIsShuttle = true;
        private Fire _fire;

        void Start(){
            _fire = this.GetComponent<Fire>();
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
    }
}