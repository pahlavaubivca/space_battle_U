using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using UnityEngine;

//using Shuttle;
//using shuttle = NMShuttle.Shuttle;

public class shuttle_move : MonoBehaviour{
    private Rigidbody2D rigidBody;

    public float speed=2f;
//    public void clickTopButton(){
//         transform.rotation = new Vector2();
//    }

    void Start(){
        rigidBody = gameObject.GetComponent<Rigidbody2D>();
    }


//    void Update(){
//        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//        transform.position = Vector3.Lerp(transform.position, mousePosition, speed / 200);
//
//        double angleDeg = Math.Atan2(transform.position.y - mousePosition.y, transform.position.x - mousePosition.x) *
//                          180 / Math.PI;
//        angleDeg = angleDeg * 0.1 * -1;
//        float deg = (float) angleDeg;
//        float rad = (float) (deg * Math.PI) / 180;
//
//        Vector3 relPosition = mousePosition - transform.position;
//        // transform.rotation = Quaternion.Lerp(transform.rotation, angl, 1);
//        // transform.localRotation = new Quaternion(0f, 0f, deg / 10, 1f);
//        // transform.rotation = Quaternion.LookRotation(relPosition, Vector3.zero);
//        // transform.rotation = Quaternion.Euler(0,0,deg);
//        
//        Vector2 mousePos = Input.mousePosition;
//        Vector3 screenPos = Camera.main.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, transform.position.z - Camera.main.transform.position.z));
//     
//        transform.rotation.eulerAngles.z = Mathf.Atan2((screenPos.y - transform.position.y), (screenPos.x - transform.position.x))*Mathf.Rad2Deg;
//    }
    private float limit = 2.5f;

    private Vector2 direction;
    private float distanceFromObject;

    void Update(){
       
    }

    void FixedUpdate(){
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y, Input.mousePosition.z - Camera.main.transform.position.z));
        double dist = Math.Sqrt(Math.Pow(mousePosition.x - transform.position.x, 2) +
                                Math.Pow(mousePosition.y - transform.position.y, 2));

        float koef = (float) dist;
        if (dist > limit){
            koef = limit * (limit / koef);
        }
        transform.position = Vector2.Lerp(transform.position, mousePosition, koef / 100);
        // Debug.Log(dist);
        //  Vector3 relPosition = mousePosition - transform.position;
//            childElementShuttle.transform.eulerAngles = new Vector3(0, 0,
//                Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) *
//                Mathf.Rad2Deg);

//        direction = (mousePosition - transform.position).normalized;
//        Debug.Log(direction);
        //distanceFromObject = (mousePosition - Camera.main.WorldToScreenPoint(transform.position)).magnitude;
//        rigidBody.AddForce(direction * speed * koef);
        // rigidBody.AddForce(transform.forward * 0.2f);
         
    }
}