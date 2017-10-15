using System;
using System.Collections.Generic;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        public Rigidbody2D bullet;
        private float bulletSpeed = 0.2f;
        private int bulletCount = 0;
        private bool firstB = false;

        Dictionary<int, Rigidbody2D> bulletDictionary = new Dictionary<int, Rigidbody2D>();

        void Start(){
            GameObject tempGO = new GameObject();
            tempGO.AddComponent<Bullet>();
            var bulletCheck = tempGO.GetComponent<Bullet>();
            if (bulletCheck != null){
                bullet = tempGO.GetComponent<Bullet>().CreateBullet();
                Destroy(tempGO);
            }
        }

        public void CalculateStart(){
            Rigidbody2D bulletInstance =
                Instantiate(bullet, transform.position, transform.rotation);
            bulletDictionary.Add(bulletCount, bulletInstance);
            bulletCount++;
        }

        private void Update(){
            if (Input.GetMouseButtonDown(0)){
                CalculateStart();
            }
        }

        public double ConvertToRadians(double angle){
            return Math.PI / 180 * angle;
        }

        private void FixedUpdate(){
            if (bulletDictionary.Count > 0){
                foreach (var v in bulletDictionary){
                    if (v.Value){
                        if (Math.Abs(transform.position.x - v.Value.transform.position.x) > 4 ||
                            Math.Abs(transform.position.y - v.Value.transform.position.y) > 4){
                            bulletDictionary.Remove(v.Key);
                            Destroy(v.Value.gameObject);
                            break;
                        }
                        else{
                            Transform vt = v.Value.transform;
                            //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                            double x = vt.position.x + Math.Cos(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                            double y = vt.position.y + Math.Sin(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                            vt.position = new Vector3((float) x, (float) y, 0);
                        }
                    }
                    else{
                        Debug.Log("not found bullet");
                        bulletDictionary.Remove(v.Key);
                        break;
                    }
                }
            }
        }
    }
}