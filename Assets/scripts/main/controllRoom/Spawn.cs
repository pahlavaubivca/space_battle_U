using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public interface ISpawnHereParams{
    float x0{ get; set; }
    float y0{ get; set; }
    float x1{ get; set; }
    float y1{ get; set; }
}

public interface ISpanwHereReturn{
    float x{ get; set; }
    float y{ get; set; }
}

public class Spawn : MonoBehaviour{
    ISpanwHereReturn coordinate;
    public ISpanwHereReturn SpawnHere(ISpawnHereParams param){
        float x = 0;
        float y = 0;
        
        coordinate.x = x;
        coordinate.y = y;
        return coordinate;
    }
}