﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using main;
using UnityEditor.IMGUI.Controls;

public class EnemyAI : MonoBehaviour{
    private GameObject _shuttle;
    private double _dist;
    private long _oldTime = 0;
    private Fire _fire;
    private float fireDistance = 2200f;

    private float attentionDistance = 2200f;

    private Vector2 toHomePoint = new Vector2(5,5);
    private float[] toHomeBoxMin;
    private float[] toHomeBoxMax;
    private float toHomeBoxHalfSize = 10f;
    private Base _base;

    void Start(){
        _shuttle = GameObject.Find("shuttle");
        _fire = gameObject.GetComponent<Fire>();
        _base = gameObject.AddComponent<Base>();
        toHomePoint = (Vector2)transform.position;

        toHomeBoxMin = new[]{transform.position.x - toHomeBoxHalfSize, transform.position.y - toHomeBoxHalfSize};
        toHomeBoxMax = new[]{transform.position.x + toHomeBoxHalfSize, transform.position.y + toHomeBoxHalfSize};
    }

    private void attentionOnShuttle(){
        _base.AngleToPoint(_shuttle.transform.position, 0.1f);
        _base.MoveGameObject(_shuttle.transform.position, 70);
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

    private void randomMove(){
        
    }

    private void goHome(){
        bool outHome = (transform.position.x > toHomeBoxMax[0] || transform.position.x < toHomeBoxMin[0]) &&
                       (transform.position.y > toHomeBoxMax[1] || transform.position.y < toHomeBoxMin[1]);
        if (outHome){
            _base.AngleToPoint(toHomePoint, 0.03f);
            float[] toPoint = _base.DefineDirectionFromCoordinate(toHomePoint.x, toHomePoint.y);
            _base.MoveGameObject(new Vector2(toPoint[0], toPoint[1]), 30);
        }
    }

    void FixedUpdate(){
        _dist = _base.Distance(_shuttle.transform.position.x, transform.position.x,
            _shuttle.transform.position.y, transform.position.y);
        fire();
        if (_dist < attentionDistance){
            attentionOnShuttle();
        } else{
            goHome();
        }
    }
}