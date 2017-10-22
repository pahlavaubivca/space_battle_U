using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour{
    public bool EnemyFire = false;
    private GameObject shuttle;
    private double _dist;
    private GameObject thisEnemy;
    private long _oldTime = 0;

    void Start(){
        shuttle = GameObject.Find("shuttle");
        thisEnemy = this.gameObject;
    }

    private void distanceToShuttle(){
        _dist = Math.Sqrt(Math.Pow(shuttle.transform.position.x - thisEnemy.transform.position.x, 2) +
                          Math.Pow(shuttle.transform.position.y - thisEnemy.transform.position.y, 2));
    }

    private void randomMovement(){
    }

    private void fire(){
        var currentTime = System.DateTime.Now.Ticks;
        if (currentTime - _oldTime > 10000000){
            Debug.Log("aaaaa");
            if (_dist < 4.5){
                EnemyFire = true;
                Debug.Log("enemy fire, dist - " + _dist);
                _oldTime = currentTime;
                
            }
            else if (EnemyFire){
                EnemyFire = false;
            }
        }
    }

    void FixedUpdate(){
        distanceToShuttle();
        fire();
    }
}