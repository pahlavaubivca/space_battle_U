using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class EnemyInstance : MonoBehaviour{
        private GameObject enemy;
        List<Rigidbody2D> enemyList = new List<Rigidbody2D>();
        private float left = 2.5f;
        private int _count = 0;

        private void Enemy(){
            SetSprite();
            enemy.AddComponent<PolygonCollider2D>();
            enemy.AddComponent<Rigidbody2D>();
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            enemy.transform.position = new Vector3(10000000, 0, 0);
            enemy.AddComponent<Enemy>();
            enemy.AddComponent<EnemyAI>();
            enemy.AddComponent<Fire>();
        }

        void Start(){
            enemy = new GameObject("enemy");
            Enemy();
        }

        public Rigidbody2D CreateEnemy(){
            Vector3 position = new Vector3(left,100000.5f,0);
            Quaternion rotation = new Quaternion(0,0,0,0);
            Rigidbody2D enemyClone =
                Instantiate(enemy.GetComponent<Rigidbody2D>(), position, rotation);
            //enemyClone.gameObject.AddComponent<PolygonCollider2D>();
            enemyClone.name = "enemy " + _count;
            enemyList.Add(enemyClone);
            _count++;
            left++;
            return enemyClone;
        }

        public void SetSprite(Sprite sprite = null){
            sprite = sprite != null ? sprite : defaultSprite();
            if (sprite != null){
                enemy.AddComponent<SpriteRenderer>();
                enemy.GetComponent<SpriteRenderer>().sprite =
                    Sprite.Create(sprite.texture, sprite.textureRect, sprite.textureRectOffset);
                enemy.GetComponent<SpriteRenderer>().color = Color.red;
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
}