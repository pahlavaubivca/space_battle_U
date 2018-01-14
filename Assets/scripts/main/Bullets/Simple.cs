using System;
using System.Collections;
using System.Collections.Generic;
using main;
using UnityEngine;

public class SimpleBullet : MonoBehaviour{
    public class BulletSimple : BulletCollection{
        public new float Speed = 8f;
        public new float Range = 450;
        public new float DestroyForce = 1;
        private Rigidbody2D rBody;
        private List<Rigidbody2D> bulletList = new List<Rigidbody2D>();

        private void Start(){
            rBody = RBody("SimpleBullet");
        }

        public override void CreateClone(Transform targetTrasnform, int counter){
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
}