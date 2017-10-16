using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyInstance : MonoBehaviour{
    private GameObject enemy = new GameObject("enemy");

    public Rigidbody2D CreateEnemy(){
        SetSprite();
        enemy.AddComponent<PolygonCollider2D>();
        enemy.AddComponent<Rigidbody2D>();
        enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
        enemy.transform.position = new Vector3(0, 0, -100f);
        return enemy
            .GetComponent<Rigidbody2D>();
    }

    public void SetSprite(Sprite sprite = null){
        sprite = sprite != null ? sprite : defaultSprite();
        if (sprite != null){
            enemy.AddComponent<SpriteRenderer>();
            enemy.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(sprite.texture, sprite.textureRect, sprite.textureRectOffset);
        }
    }

    private Sprite defaultSprite(){
        var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
        Sprite sprite = null;
        foreach (var val in sprites){
            if (val.name == "index_2.1_0"){
                sprite = val;
            }
        }
        return sprite;
    }
}