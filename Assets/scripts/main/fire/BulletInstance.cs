using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEditor;

namespace main{
    
    public abstract class BulletCollection : MonoBehaviour{
        public float Speed{ get; set; }
        public float Range{ get; set; }
        public float DestroyForce{ get; set; }
        public abstract Rigidbody2D RBody();
        public abstract void Fly();
        public abstract void CreateClone(Transform transform);

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
    }

    public class BulletOwner : MonoBehaviour{
        public GameObject Owner;
    }

    public static class ImplementedBullet{
        public static Dictionary<int, BulletCollection> ImplementedBulletDictionary = new Dictionary<int, BulletCollection>();
    }

    public class BulletSimple : BulletCollection{
        public new float Speed = 8f;
        public new float Range = 450;
        public new float DestroyForce = 1;
        private Rigidbody2D rBody;
        private List<Rigidbody2D> bulletList = new List<Rigidbody2D>();

        private void Start(){
            rBody = RBody();
        }

        public override Rigidbody2D RBody(){
            Sprite _sprite = getSprite();
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

        public override void CreateClone(Transform targetTrasnform){
            Vector3 bulletSize = rBody.gameObject.GetComponent<Renderer>().bounds.size;
            float ang = targetTrasnform.eulerAngles.z;
            int forX = ang > 180 ? -1 : 1;
            int forY = ang > 90 && ang < 270 ? 1 : -1;
            Vector2 bulletPosition = new Vector2(targetTrasnform.position.x + bulletSize.x / 2 * forX,
                targetTrasnform.position.y + bulletSize.y / 2 * forY);

            Rigidbody2D bulletInstance =
                Instantiate(rBody, bulletPosition, targetTrasnform.rotation);
            bulletInstance.gameObject.AddComponent<BulletOwner>().Owner = targetTrasnform.gameObject;
            bulletList.Add(bulletInstance);
        }

        public override void Fly(){
            if (bulletList.Count > 0){
                foreach (var bullet in bulletList){
                    if (bullet != null){
                        GameObject owner = bullet.gameObject.GetComponent<BulletOwner>().Owner;
                        if (Math.Abs(owner.transform.position.x - bullet.transform.position.x) > Range ||
                            Math.Abs(owner.transform.position.y - bullet.transform.position.y) > Range){
                            bulletList.Remove(bullet);
                            Destroy(bullet.gameObject);
                            break;
                        } else{
                            Transform vt = bullet.transform;
                            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * Speed;
                            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * Speed;
                            vt.position = new Vector3((float) x, (float) y, 0);
                        }
                    } else{
                        bulletList.Remove(bullet);
                        break;
                    }
                }
            }
        }
    }

    public class BulletShotGunSimple : BulletCollection{
        // class must generate and save all own clones
        public override Rigidbody2D RBody(){
            return null;
        }

        public float Speed = 5f;
        public float Range = 200;
        public float DestroyForce = 7;

        public override void Fly(){
//            Transform vt = bullet.Key.transform;
//            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
//            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            vt.position = new Vector3((float) x, (float) y, 0);
        }

        public override void CreateClone(Transform t){
        }
    }

    public class BulletLaserSimple : BulletCollection{
        // class must generate and save all own clones
        public override Rigidbody2D RBody(){
            return null;
        }

        public float Speed = 80f;
        public float Range = 950;
        public float DestroyForce = 3;

        public override void Fly(){
//            Transform vt = bullet.Key.transform;
//            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
//            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            vt.position = new Vector3((float) x, (float) y, 0);
        }

        public override void CreateClone(Transform t){
        }
    }

    public class BulletRocketSimple : BulletCollection{
        // class must generate and save all own clones
        public override Rigidbody2D RBody(){
            return null;
        }

        public float Speed = 8f;
        public float Range = 450;
        public float DestroyForce = 10;

        public override void Fly(){
//            Transform vt = bullet.Key.transform;
//            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
//            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bullet.Value.Speed;
//            vt.position = new Vector3((float) x, (float) y, 0);
        }

        public override void CreateClone(Transform t){
        }
    }

    public class BulletInstance : MonoBehaviour{
        private int bulletCount = 1;

        void Start(){
            var bs = gameObject.AddComponent<BulletSimple>();
            ImplementedBullet.ImplementedBulletDictionary.Add(bulletCount++, bs);
        }

        private void FixedUpdate(){
            foreach (var bullet in ImplementedBullet.ImplementedBulletDictionary){
                bullet.Value.Fly();
            }
        }
    }
}