using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using main;

public class EnemyAI : MonoBehaviour{
    private GameObject _shuttle;
    private double _dist;
    private GameObject _thisEnemy;
    private long _oldTime = 0;
    private Fire _fire;
    private float fireDistance = 240f;

    void Start(){
        _shuttle = GameObject.Find("shuttle");
        _thisEnemy = this.gameObject;
        _fire = this.GetComponent<Fire>();
    }

    private void distanceToShuttle(){
        _dist = Math.Sqrt(Math.Pow(_shuttle.transform.position.x - _thisEnemy.transform.position.x, 2) +
                          Math.Pow(_shuttle.transform.position.y - _thisEnemy.transform.position.y, 2));
    }

    private void attentionOnShuttle(){
        if (_dist < fireDistance){
            transform.transform.eulerAngles = new Vector3(0, 0,
                Mathf.Atan2((_shuttle.gameObject.transform.position.y - transform.position.y),
                    (_shuttle.gameObject.transform.position.x - transform.position.x)) *
                Mathf.Rad2Deg);
        }
    }

    private void fire(){
        var currentTime = System.DateTime.Now.Ticks;
        if (currentTime - _oldTime > 10000000){
            if (_dist < fireDistance){
               _fire.CalculateStart();
            }
            _oldTime = currentTime;
        }
    }

    void FixedUpdate(){
        distanceToShuttle();
        fire();
        attentionOnShuttle();
    }
}