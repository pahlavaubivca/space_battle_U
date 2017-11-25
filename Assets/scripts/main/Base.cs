using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Base : MonoBehaviour {
	private Rigidbody2D _rigidBody;
	
	public void MoveGameObject(Vector2 toPoint, float maxSpeed, float limit = 0){
		if (_rigidBody == null){
			_rigidBody = gameObject.GetComponent<Rigidbody2D>();
		}
		if (limit != 0){
			double _dist = Distance(toPoint.x, 0, toPoint.y, 0);
			if (_dist > limit){
				double x = limit * Math.Cos(transform.transform.eulerAngles.z * Mathf.Deg2Rad);
				double y = limit * Math.Sin(transform.transform.eulerAngles.z * Mathf.Deg2Rad);
				toPoint = new Vector2((float) x, (float) y);
			}
		}
		_rigidBody.AddForce(toPoint);
		if (_rigidBody.velocity.magnitude > maxSpeed){
			_rigidBody.velocity = _rigidBody.velocity.normalized * maxSpeed;
		}
	}

	public void AngleToPoint(Vector2 to, float delta = 1){
		var diffY = to.y - transform.position.y;
		var diffX = to.x - transform.position.x;
		Vector3 needAngle = new Vector3(0, 0,
			Mathf.Atan2(diffY, diffX) *
			Mathf.Rad2Deg);
		var ang = Mathf.LerpAngle(transform.eulerAngles.z, needAngle.z, delta);
		transform.transform.eulerAngles = new Vector3(0,0,ang);
	}
	public float Distance(float x0, float x1, float y0, float y1){
		return (float) Math.Sqrt(Math.Pow(x0 - x1, 2) +
		                         Math.Pow(y0 - y1, 2));
	}
}
