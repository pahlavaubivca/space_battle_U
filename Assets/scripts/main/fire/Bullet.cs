using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace main{
    public class BulletInstance{
        public Rigidbody2D RBody;
        public float Speed;
        public float Range;
        public float DestroyForce;
        public int EnumType;
    }

    public class UnityBulletInstance : MonoBehaviour{
        public float DestroyForce;
    }

    public static class ImplementedBullet{
        public static List<BulletInstance> ImplementedBulletList = new List<BulletInstance>();
        
    }
    
    public class Bullet : MonoBehaviour{
        public BulletInstance BulletInstanceSimple;
        public BulletInstance BulletInstanceShotgun;
        public BulletInstance BulletInstanceSimpleLaser;
        public BulletInstance BulletInstanceSimpleRocket;
        private Sprite _sprite;

        void Start(){
            BulletInstanceSimple = new BulletInstance();
            BulletInstanceSimple.RBody = CreateSimpleBullet();
            BulletInstanceSimple.Speed = 8f;
            BulletInstanceSimple.Range = 450;
            BulletInstanceSimple.DestroyForce = 1;
            BulletInstanceSimple.EnumType = 1;
            
            BulletInstanceShotgun =  new BulletInstance();
            BulletInstanceShotgun.RBody = CreateShotgunBullet();
            BulletInstanceShotgun.Speed = 5f;
            BulletInstanceShotgun.Range = 200;
            BulletInstanceShotgun.DestroyForce = 7;
            BulletInstanceShotgun.EnumType = 2;

            BulletInstanceSimpleLaser =  new BulletInstance();
            BulletInstanceSimpleLaser.RBody = CreateSimpleLaser();
            BulletInstanceSimpleLaser.Speed = 80f;
            BulletInstanceSimpleLaser.Range = 950;
            BulletInstanceSimpleLaser.DestroyForce = 3;
            BulletInstanceSimpleLaser.EnumType = 3;

            BulletInstanceSimpleRocket =  new BulletInstance();
            BulletInstanceSimpleRocket.RBody = CreateSimpleRocket();
            BulletInstanceSimpleRocket.Speed = 5f;
            BulletInstanceSimpleRocket.Range = 1450;
            BulletInstanceSimpleRocket.DestroyForce = 10;
            BulletInstanceSimpleRocket.EnumType = 4;
            ImplementedBullet.ImplementedBulletList.AddRange(new []{
                BulletInstanceSimple,
                BulletInstanceShotgun,
                BulletInstanceSimpleLaser,
                BulletInstanceSimpleRocket
            });
        }

        private Rigidbody2D CreateSimpleBullet(){
            getSprite();
            GameObject bullet = new GameObject("bulletSimple");
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

        private Rigidbody2D CreateShotgunBullet(){
            GameObject shotgunBullet = new GameObject("bulletShotgun");

            return shotgunBullet.GetComponent<Rigidbody2D>();
        }

        private static Rigidbody2D CreateSimpleLaser(){
            GameObject simpleLaser = new GameObject("bulletSimpleLaser");

            return simpleLaser.GetComponent<Rigidbody2D>();
        }

        private Rigidbody2D CreateSimpleRocket(){
            GameObject simpleRocket = new GameObject("bulletSimpleRocket");

            return simpleRocket.GetComponent<Rigidbody2D>();
        }

        private void getSprite(){
            var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
            foreach (var val in sprites){
                if (val.name == "index_2.1_bullet"){
                    _sprite = val;
                }
            }
        }
    }
}