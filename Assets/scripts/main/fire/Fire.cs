using System;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        private Rigidbody2D Bullet;
        private float bulletSpeed = 0.2f;
        private GameObject thisUnit;
        private EnemyAI _enemyAi;

        private List<Rigidbody2D> bulletList = new List<Rigidbody2D>();

        void Start(){
            GameObject tempGO = new GameObject("tempGo");
            var _bullet = GameObject.Find("bullet");
            if (_bullet == null){
                Debug.Log("start fire script");
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
            _enemyAi = thisUnit.GetComponent<EnemyAI>();
        }

        public void CalculateStart(){
            Rigidbody2D bulletInstance =
                Instantiate(Bullet, thisUnit.transform.position, thisUnit.transform.rotation);
            bulletList.Add(bulletInstance);
        }

        private void Update(){
            if (Input.GetMouseButtonDown(0) && thisUnit.name == "shuttle"){
                CalculateStart();
            }
        }

        public double ConvertToRadians(double angle){
            return Math.PI / 180 * angle;
        }

        private void FixedUpdate(){
            if (bulletList.Count > 0){
                foreach (var bullet in bulletList){
                    if (bullet != null){
                        if (Math.Abs(thisUnit.transform.position.x - bullet.transform.position.x) > 4 ||
                            Math.Abs(thisUnit.transform.position.y - bullet.transform.position.y) > 4){
                            bulletList.Remove(bullet);
                            Destroy(bullet.gameObject);
                            break;
                        } else{
                            Transform vt = bullet.transform;
                            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                            double x = vt.position.x + Math.Cos(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                            double y = vt.position.y + Math.Sin(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                            vt.position = new Vector3((float) x, (float) y, 0);
                        }
                    }
                }
            }
            if (_enemyAi && _enemyAi.EnemyFire){
                Debug.Log("fire class, trigger fire");
                CalculateStart();
            }
        }
    }
}