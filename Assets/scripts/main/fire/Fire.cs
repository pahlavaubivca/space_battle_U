using System;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        private Rigidbody2D Bullet;
        private float bulletSpeed = 8f;
        private GameObject thisUnit;
        private float bulletDistance = 450;

        private List<Rigidbody2D> bulletList = new List<Rigidbody2D>();

        void Start(){
            var _bullet = GameObject.Find("bullet");
            if (_bullet == null){
                GameObject tempGO = new GameObject("tempGo");
                tempGO.AddComponent<Bullet>();
                var bulletCheck = tempGO.GetComponent<Bullet>();
                if (bulletCheck != null){
                    Bullet = tempGO.GetComponent<Bullet>().CreateBullet();
                    Destroy(tempGO);
                }
            } else{
                Bullet = _bullet.GetComponent<Rigidbody2D>();
            }
            thisUnit = this.gameObject;
        }

        public void CalculateStart(){
            Vector3 bulletSize = Bullet.GetComponent<Renderer>().bounds.size;
            float ang = thisUnit.transform.eulerAngles.z;
            int forX = ang > 180 ? -1 : 1;
            int forY = ang > 90 && ang < 270 ? 1 : -1;
            Vector2 bulletPosition = new Vector2(thisUnit.transform.position.x + bulletSize.x / 2 * forX,
                thisUnit.transform.position.y + bulletSize.y / 2 * forY);

            Rigidbody2D bulletInstance =
                Instantiate(Bullet, bulletPosition, thisUnit.transform.rotation);
            bulletInstance.gameObject.name = "bullet " + thisUnit.name;
            bulletList.Add(bulletInstance);
        }

        private void FixedUpdate(){
            if (bulletList.Count > 0){
                foreach (var bullet in bulletList){
                    if (bullet != null){
                        if (Math.Abs(thisUnit.transform.position.x - bullet.transform.position.x) > bulletDistance ||
                            Math.Abs(thisUnit.transform.position.y - bullet.transform.position.y) > bulletDistance){
                            bulletList.Remove(bullet);
                            Destroy(bullet.gameObject);
                            break;
                        } else{
                            Transform vt = bullet.transform;
                            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                            double x = vt.position.x + Math.Cos(vt.eulerAngles.z * Mathf.Deg2Rad) * bulletSpeed;
                            double y = vt.position.y + Math.Sin(vt.eulerAngles.z * Mathf.Deg2Rad) * bulletSpeed;
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