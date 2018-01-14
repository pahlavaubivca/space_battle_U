using System;
using System.Collections;
using UnityEngine;
//using System.Collections;
using System.Collections.Generic;

namespace main{
    public class BulletInstance : MonoBehaviour{
        private int bulletCount = 1;

        void Start(){
            ImplementedBullet.ImplementedBulletDictionary.Add(bulletCount++, gameObject.AddComponent<SimpleBullet.BulletSimple>());
            ImplementedBullet.ImplementedBulletDictionary.Add(bulletCount++, gameObject.AddComponent<ShotgunBullet.BulletShotgunSimple>());
        }

        private void FixedUpdate(){
            foreach (var bullet in ImplementedBullet.ImplementedBulletDictionary){
                bullet.Value.Fly();
            }
        }
    }
    public abstract class BulletCollection : MonoBehaviour{
        public float Speed{ get; set; }
        public float Range{ get; set; }
        public float DestroyForce{ get; set; }
        public abstract void Fly();
        public abstract void CreateClone(Transform transform, int counter = 0);

        public Sprite getSprite(){
            var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
            Sprite result = null;
            foreach (var val in sprites){
                if (val.name == "index_2.1_bullet"){
                    result = val;
                }
            }
            return result;
        }

        public Rigidbody2D RBody(string name){
            Sprite _sprite = getSprite();
            GameObject bullet = new GameObject(name);
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(_sprite.texture, _sprite.textureRect, _sprite.textureRectOffset);
            bullet.AddComponent<CircleCollider2D>();
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<CircleCollider2D>().isTrigger = true;
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.transform.position = new Vector3(-100000, 0, 0);
            bullet.transform.localScale = new Vector3(50, 50, 0);
            return bullet.GetComponent<Rigidbody2D>();
        }
    }

    public class BulletOwner : MonoBehaviour{
        public GameObject Owner;
    }

    public static class ImplementedBullet{
        public static Dictionary<int, BulletCollection> ImplementedBulletDictionary = new Dictionary<int, BulletCollection>();
    }

    
}