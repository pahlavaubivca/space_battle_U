using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

namespace main{
    public abstract class BulletCollection2{
        public abstract Rigidbody2D RBody{ get; set; }
        public abstract float Speed{ get; set; }
        public abstract float Range{ get; set; }
        public abstract float DestroyForce{ get; set; }
        public abstract void Fly();
    }

    public class BulletCollection{
        // abstract
        public Rigidbody2D RBody;

        public float Speed;
        public float Range;
        public float DestroyForce;
        public string DirectionType;
        public float SplashRange;
        public int EnumType;

        public void Fly(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
        }
    }

    public class UnityBulletInstance : MonoBehaviour{
        public float DestroyForce;
    }

    public static class ImplementedBullet{
        public static List<BulletCollection> ImplementedBulletList = new List<BulletCollection>(); // TODO dictionary Key = enum bullet type
    }

    public class BulletSimple : BulletCollection2{
        // class must generate and save all own clones
        public override Rigidbody2D RBody = null;

        public override float Speed = 5f;
        public override float Range = 1450;
        public override float DestroyForce = 1;

        public override void Fly(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
            Transform vt = bullet.Key.transform;
            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            vt.position = new Vector3((float) x, (float) y, 0);
        }
    }
    public class BulletShotGunSimple : BulletCollection2{
        // class must generate and save all own clones
        public override Rigidbody2D RBody = null;

        public override float Speed = 5f;
        public override float Range = 200;
        public override float DestroyForce = 7;

        public override void Fly(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
            Transform vt = bullet.Key.transform;
            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            vt.position = new Vector3((float) x, (float) y, 0);
        }
    }
    public class BulletLaserSimple : BulletCollection2{
        // class must generate and save all own clones
        public override Rigidbody2D RBody = null;

        public override float Speed = 80f;
        public override float Range = 950;
        public override float DestroyForce = 3;

        public override void Fly(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
            Transform vt = bullet.Key.transform;
            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            vt.position = new Vector3((float) x, (float) y, 0);
        }
    }
    public class BulletRocketSimple : BulletCollection2{
        // class must generate and save all own clones
        public override Rigidbody2D RBody = null;

        public override float Speed = 8f;
        public override float Range = 450;
        public override float DestroyForce = 10;

        public override void Fly(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
            Transform vt = bullet.Key.transform;
            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            vt.position = new Vector3((float) x, (float) y, 0);
        }
    }

    public class BulletInstance2 : MonoBehaviour{
        
    }

    public class BulletInstance : MonoBehaviour{
        public BulletCollection BulletCollectionSimple;
        public BulletCollection BulletCollectionShotgun;
        public BulletCollection BulletCollectionSimpleLaser;
        public BulletCollection BulletCollectionSimpleRocket;
        private Sprite _sprite;

        void Start(){
            BulletCollectionSimple = new BulletCollection(); // all bullet discretion class
            BulletCollectionSimple.RBody = CreateSimpleBullet();
            BulletCollectionSimple.Speed = 8f;
            BulletCollectionSimple.Range = 450;
            BulletCollectionSimple.DestroyForce = 1;
            BulletCollectionSimple.EnumType = 1;
            BulletCollectionSimple.DirectionType = "straight";
            BulletCollectionSimple.Fly = StaightDirection;

            BulletCollectionShotgun = new BulletCollection();
            BulletCollectionShotgun.RBody = CreateShotgunBullet();
            BulletCollectionShotgun.Speed = 5f;
            BulletCollectionShotgun.Range = 200;
            BulletCollectionShotgun.DestroyForce = 7;
            BulletCollectionShotgun.EnumType = 2;
            BulletCollectionShotgun.DirectionType = "splash";
            BulletCollectionShotgun.SplashRange = 1.5f;

            BulletCollectionSimpleLaser = new BulletCollection();
            BulletCollectionSimpleLaser.RBody = CreateSimpleLaser();
            BulletCollectionSimpleLaser.Speed = 80f;
            BulletCollectionSimpleLaser.Range = 950;
            BulletCollectionSimpleLaser.DestroyForce = 3;
            BulletCollectionSimpleLaser.EnumType = 3;
            BulletCollectionSimpleLaser.DirectionType = "straight";

            BulletCollectionSimpleRocket = new BulletCollection();
            BulletCollectionSimpleRocket.RBody = CreateSimpleRocket();
            BulletCollectionSimpleRocket.Speed = 5f;
            BulletCollectionSimpleRocket.Range = 1450;
            BulletCollectionSimpleRocket.DestroyForce = 10;
            BulletCollectionSimpleRocket.EnumType = 4;
            BulletCollectionSimpleRocket.DirectionType = "straight";
            ImplementedBullet.ImplementedBulletList.AddRange(new[]{
                BulletCollectionSimple,
                BulletCollectionShotgun,
                BulletCollectionSimpleLaser,
                BulletCollectionSimpleRocket
            });
        }

        public void StaightDirection(KeyValuePair<Rigidbody2D, BulletCollection> bullet){
            Transform vt = bullet.Key.transform;
            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
            vt.position = new Vector3((float) x, (float) y, 0);
        }

        private Rigidbody2D CreateRigidbody2DSimpleBullet(){
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