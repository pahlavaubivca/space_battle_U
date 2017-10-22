using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class EnemyInstance : MonoBehaviour{
        private GameObject enemy;
        List<Rigidbody2D> enemyList = new List<Rigidbody2D>();
        private float left = 1.5f;

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
           // Debug.Log("enemy instance start");
            Enemy();
        }

        public void CreateEnemy(){
            Vector3 position = new Vector3(left,0.5f,0);
            left++;
            Rigidbody2D enemyClone =
                Instantiate(enemy.GetComponent<Rigidbody2D>(), position, transform.rotation);
            //enemyClone.gameObject.AddComponent<PolygonCollider2D>();
            enemyList.Add(enemyClone);
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