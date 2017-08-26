using System;
using UnityEngine;
public class shuttle_move : MonoBehaviour{
    private float limit = 2.5f;
    private Vector3 mousePosition;
    private double dist;

    void FixedUpdate(){
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        dist = Math.Sqrt(Math.Pow(mousePosition.x - transform.position.x, 2) +
                         Math.Pow(mousePosition.y - transform.position.y, 2));

        float koef = (float) dist;
        if (dist > limit){
            koef = limit * (limit / koef);
        }
        transform.position = Vector2.Lerp(transform.position, mousePosition, koef / 100);
    }
}