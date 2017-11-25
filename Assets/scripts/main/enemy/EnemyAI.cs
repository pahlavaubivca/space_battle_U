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
    private float attentionDistance = 400f;
    private Base _base;

    void Start(){
        _shuttle = GameObject.Find("shuttle");
        _thisEnemy = this.gameObject;
        _fire = this.GetComponent<Fire>();
        _base = gameObject.AddComponent<Base>();
    }

    private void attentionOnShuttle(){
        if (_dist < attentionDistance){
            _base.AngleToPoint(_shuttle.gameObject.transform.position,0.1f);
            _base.MoveGameObject(_shuttle.transform.position, 100, 70);
        } else{
            
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
        _dist = _base.Distance(_shuttle.transform.position.x, _thisEnemy.transform.position.x,
            _shuttle.transform.position.y, _thisEnemy.transform.position.y);
        fire();
        attentionOnShuttle();
    }
}