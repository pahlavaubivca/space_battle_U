using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.EventSystems;


public class Enemy : MonoBehaviour{
    Regex bulletMatch = new Regex("bullet");

    public void OnCollisionEnter2D(Collision2D collision){
        Debug.Log("collision");
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (bulletMatch.Match(other.gameObject.name).Length > 0){
            Destroy(other.gameObject);
            Debug.Log("trigger with bullet");
        }
    }
}