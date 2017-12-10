using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using UnityEngine;

public class Base : MonoBehaviour{
    private Rigidbody2D _rigidBody;
    private float[] pArr;

    /*
     * method who move gameObject to needed point
     * params:
     *  - toPoint(Vector2) global coordinate needed point
     *  - maxSpeed(float) max allowed speed
     *  - limit(float) limit dist to toPoint coordinate
     */
    public void MoveGameObject(Vector2 toPoint, float maxSpeed, float limit = 0){
        if (_rigidBody == null){
            _rigidBody = gameObject.GetComponent<Rigidbody2D>();
        }
        float _dist = Distance(toPoint.x, 0, toPoint.y, 0);
        if (_dist > limit && limit != 0){
            pArr = PointsFromVectorAndAngle(limit, transform.transform.eulerAngles.z);
        } else{
            pArr = PointsFromVectorAndAngle(_dist, transform.transform.eulerAngles.z);
        }
        toPoint = new Vector2(pArr[0], pArr[1]); // next needed point relative current gameObject
        _rigidBody.AddForce(toPoint); // IMPORTANT AddForce work with coordinate relative current gameObject, not global coordinate
        if (_rigidBody.velocity.magnitude > maxSpeed){ // if current velocity more as max allow speed
            _rigidBody.velocity = _rigidBody.velocity.normalized * maxSpeed;
        }
    }

    public float[] DefineDirectionFromCoordinate(float x, float y){
        float distance = Distance(transform.position.x, x, transform.position.y, y);
        float angle = AngleBetween2PointsInDeg(x, transform.position.x, y, transform.position.y);
        float[] points = PointsFromVectorAndAngle(distance, angle);
        return new[]{points[0], points[1]};
    }

    public void AngleToPoint(Vector2 to, float delta = 1){
        var diffY = to.y - transform.position.y;
        var diffX = to.x - transform.position.x;
        Vector3 needAngle = new Vector3(0, 0,
            Mathf.Atan2(diffY, diffX) *
            Mathf.Rad2Deg);
        var ang = Mathf.LerpAngle(transform.eulerAngles.z, needAngle.z, delta);
        transform.transform.eulerAngles = new Vector3(0, 0, ang);
    }

    public float Distance(float x0, float x1, float y0, float y1){
        return Mathf.Sqrt(Mathf.Pow(x0 - x1, 2) +
                          Mathf.Pow(y0 - y1, 2));
    }

    public float AngleBetween2PointsInDeg(float x, float y, float x1, float y1){
        return Mathf.Atan2(y - y1, x - x1) * Mathf.Rad2Deg;
    }
    
    /*
     * important method for AddForce vector
     * AddForce work with coordinate relative own gameObject, not global coordinate
     * params:
     *  - distance(float) distance to next point
     *  - angle(float) angle to next point
     */
    public float[] PointsFromVectorAndAngle(float distance, float angle){ 
        float x = distance * Mathf.Cos(angle * Mathf.Deg2Rad);
        float y = distance * Mathf.Sin(angle * Mathf.Deg2Rad);
        return new[]{x, y};
    }
}