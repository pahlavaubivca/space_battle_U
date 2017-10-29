using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;

public interface ISpawnHereParams{
    float x0{ get; set; }
    float y0{ get; set; }
    float x1{ get; set; }
    float y1{ get; set; }
    float r{ get; set; }
}

public interface ISpanwHereReturn{
    float x{ get; set; }
    float y{ get; set; }
}

public class Spawn : MonoBehaviour{
    ISpanwHereReturn coordinate;
    private List<Bounds> busyPoints = new List<Bounds>();

    private void getColliderInArea(){
        Collider2D[] coll = Physics2D.OverlapCircleAll(new Vector2(-3, 1), 5f);
        foreach (Collider2D c in coll){
            busyPoints.Add(c.bounds);
        }
    }

    public ISpanwHereReturn SpawnHere(ISpawnHereParams param){
        float x = 0;
        float y = 0;
        getColliderInArea();
        coordinate.x = x;
        coordinate.y = y;
        return coordinate;
    }
}