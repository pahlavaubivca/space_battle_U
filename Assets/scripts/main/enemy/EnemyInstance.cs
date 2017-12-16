using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class EnemyInstance : MonoBehaviour{
        public int BulletType = 1;
        private GameObject enemy;
        List<Rigidbody2D> enemyList = new List<Rigidbody2D>();
        private float left = 100.5f;
        private int _count = 0;
        private Spawn _spawn;

        private void Enemy(){
            SetSprite();
            enemy.AddComponent<PolygonCollider2D>();
            enemy.AddComponent<Rigidbody2D>();
            enemy.GetComponent<Rigidbody2D>().gravityScale = 0;
            enemy.GetComponent<Rigidbody2D>().mass = 0.3f;
            enemy.transform.position = new Vector3(10000000, 0, 0);
            enemy.transform.localScale = new Vector3(50, 50, 0);
        }

        void Start(){
            enemy = new GameObject("enemy");
            _spawn = gameObject.AddComponent<Spawn>();
            Enemy();
        }

        public Rigidbody2D CreateEnemy(float x, float y){
            Bounds bound = enemy.gameObject.GetComponent<Renderer>().bounds;
            float[] arr = _spawn.GetComponent<Spawn>().SpawnHere(x, y, bound.size.x, bound.size.y);
            Vector3 position = new Vector3(arr[0], arr[1], 0);
            Quaternion rotation = new Quaternion(0, 0, 0, 0);
            Rigidbody2D enemyClone = Instantiate(enemy.GetComponent<Rigidbody2D>(), position, rotation);
            enemyClone.gameObject.AddComponent<EnemyAI>();
            enemyClone.gameObject.AddComponent<Enemy>();
            enemyClone.gameObject.AddComponent<Fire>();
            enemyClone.name = "enemy " + _count;
            enemyList.Add(enemyClone);
            _count++;
            left++;
            return enemyClone;
        }

        public void SetSprite(Sprite sprite = null){
            sprite = sprite != null ? sprite : defaultSprite();
            // TODO define how calculate offset for sprite without gavno koefficientiv
            Vector2 offset = new Vector2(sprite.bounds.max.x * 1.13f / 2, sprite.bounds.max.y * 1.65f / 2);
            enemy.AddComponent<SpriteRenderer>();
            enemy.GetComponent<SpriteRenderer>().sprite = Sprite.Create(sprite.texture, sprite.textureRect, offset);
            enemy.GetComponent<SpriteRenderer>().color = Color.red;
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