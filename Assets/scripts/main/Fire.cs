using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using Object = UnityEngine.Object;

namespace main{
    public class Fire : MonoBehaviour{
        private static Rigidbody2D _body;

        public Rigidbody bulletPrefab;
        public GameObject bullet;
        public Transform firePosition;
        private float bulletSpeed = 0.2f;
        private static Sprite _sprite;
        private int bulletCount = 0;
        private bool firstB = false;

        Dictionary<int, Rigidbody2D> bulletDictionary = new Dictionary<int, Rigidbody2D>();

        void Start(){
            getSprite();
            createFirstBullet();
            _body = gameObject.GetComponent<Rigidbody2D>();
        }

        public void CalculateStart(){
            Rigidbody2D bulletInstance =
                Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            bulletDictionary.Add(bulletCount, bulletInstance);
            bulletCount++;
        }

        

        private void createFirstBullet(){
            bullet = new GameObject("bullet");
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(_sprite.texture, _sprite.textureRect, _sprite.textureRectOffset);
//            bullet.AddComponent<Collider2D>();
//            bullet.GetComponent<Collider2D>().isTrigger = true;
            bullet.AddComponent<Rigidbody2D>();
            bullet.GetComponent<Rigidbody2D>().gravityScale = 0;
            bullet.transform.position = new Vector3(0, 0, -100f);
        }

        private void getSprite(){
            var sprites = Resources.LoadAll<Sprite>("source/index_2.1");
            foreach (var val in sprites){
                if (val.name == "index_2.1_bullet"){
                    _sprite = val;
                }
            }
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
                    if (Math.Abs(transform.position.x - v.Value.transform.position.x) > 14 ||
                        Math.Abs(transform.position.y - v.Value.transform.position.y) > 14){
                        bulletDictionary.Remove(v.Key);
                        Destroy(v.Value.gameObject);
                        break;
                    }
                    else{
                        Transform vt = v.Value.transform;
                        //var l = 0.1 / Math.Cos(vt.eulerAngles.z); // length gipotenyza from katet and angle
                        double x = vt.position.x + Math.Cos(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                        double y = vt.position.y + Math.Sin(ConvertToRadians(vt.eulerAngles.z)) * bulletSpeed;
                        vt.position = new Vector3((float) x, (float) y, 1);
                    }
                }
            }
        }
    }
}