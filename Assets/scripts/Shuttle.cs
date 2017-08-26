using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shuttle : MonoBehaviour{
    public Rigidbody2D rbb;

    void Start(){
        rbb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update(){
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.transform.eulerAngles = new Vector3(0, 0,
            Mathf.Atan2((mousePosition.y - transform.position.y), (mousePosition.x - transform.position.x)) *
            Mathf.Rad2Deg);
        
    }
}