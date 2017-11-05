using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.Assertions.Comparers;
using Random = System.Random;

public interface ISpanwHereReturn{
    float x{ get; set; }
    float y{ get; set; }
}

public class Spawn : MonoBehaviour{
    ISpanwHereReturn coordinate;
    private List<Bounds> busyPoints = new List<Bounds>();
    private float _x0;
    private float _y0;

    private float boxWidth;
    private float boxHeight;

    private bool matchBox(){
        bool _collide = false;
        Collider2D collide = Physics2D.OverlapBox(new Vector2(_x0, _y0), new Vector2(boxWidth, boxHeight), 0);
        if (collide){
            _collide = true;
        }
        return _collide;
    }

    private void getFreePlace(){
        Random _rand = new Random();
        float tempX;
        float tempY;
        float step = 0.3f;
        int iterator = 8;
        int startCount = _rand.Next(0, iterator - 1);
        int oldStartCount = startCount;
        while (matchBox()){
            if (startCount == 0 || startCount == iterator / 2){
                tempX = 0;
            } else if (startCount < iterator / 2){
                tempX = 1;
            } else{
                tempX = -1;
            }
            if (startCount < iterator / 4 || startCount > iterator / 4 * 3){
                tempY = 1;
            } else if (startCount == iterator / 4 || startCount == iterator / 4 * 3){
                tempY = 0;
            } else{
                tempY = -1;
            }
            _x0 = _x0 + tempX + step * tempX;
            _y0 = _y0 + tempY + step * tempY;
            if (startCount < iterator){
                startCount++;
            } else{
                startCount = oldStartCount;
                step++;
            }
        }
    }

    public float[] SpawnHere(float x0, float y0, float width, float height){
        _x0 = x0;
        _y0 = y0;
        boxWidth = width;
        boxHeight = height;
        getFreePlace();
        float[] arr = {_x0, _y0};
        return arr;
    }
}