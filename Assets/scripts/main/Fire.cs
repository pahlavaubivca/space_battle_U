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
        public float bulletSpeed = 0.0000002f;
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
            //Quaternion rotation = Quaternion.Euler(new Vector2(0, 0, transform.eulerAngles.z));
//            var asd = Object.FindObjectOfType<Shuttle>();
//            var qwe = asd;

//            var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//            var pos = _mousePosition;
            //var asd = transform;
            //asd.forward = new Vector2(transform.position.x, transform.position.y);
            //asd.position = _mousePosition;
            Rigidbody2D bulletInstance =
                Instantiate(bullet.GetComponent<Rigidbody2D>(), transform.position, transform.rotation);
            //  bulletInstance.transform.position = new Vector2(_mousePosition.x, _mousePosition.y);


//            bulletInstance.transform.position = new Vector3(transform.position.x,transform.position.y,0);
//            bulletInstance.transform.eulerAngles = new Vector3(0,0,transform.eulerAngles.z);
//            bulletInstance.transform.position = transform.position;
//            bulletInstance.transform.eulerAngles = transform.eulerAngles;
            // bulletInstance.transform.Translate(transform.position.x, transform.position.y, transform.eulerAngles.z);
            //bulletInstance.transform.position = Vector3.MoveTowards(transform.position, _body.transform.position, bulletSpeed);

            bulletDictionary.Add(bulletCount, bulletInstance);
            bulletCount++;
        }

        private void createFirstBullet(){
            bullet = new GameObject("bullet");
            bullet.AddComponent<SpriteRenderer>();
            bullet.GetComponent<SpriteRenderer>().sprite =
                Sprite.Create(_sprite.texture, _sprite.textureRect, _sprite.textureRectOffset);

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
            return (Math.PI / 180) * angle;
        }

        private void FixedUpdate(){
            var asd = false;
            if (bulletDictionary.Count > 0){
                foreach (var v in bulletDictionary){
//                    v.Value.transform.position = new Vector3(1, 1, v.Value.transform.eulerAngles.z);    
//                    v.Value.AddForce(v.Value.transform.position * bulletSpeed);
//                    v.Value.transform.position = transform.TransformDirection(Vector3.forward * 1000);
                    //v.Value.velocity = transform.TransformDirection(v.Value.transform * 10);
                    if (Math.Abs(transform.position.x - v.Value.transform.position.x) > 4 ||
                        Math.Abs(transform.position.y - v.Value.transform.position.y) > 4){
                        bulletDictionary.Remove(v.Key);
                        // Destroy(v.Value.gameObject);
                        break;
                    }
                    else{
                        
                        
                        var vt = v.Value.transform;
                        var l = 0.1 / Math.Cos(vt.eulerAngles.z);
                        var x = vt.position.x + Math.Cos(ConvertToRadians(vt.eulerAngles.z)) * l;
                        var y = vt.position.y + Math.Sin(ConvertToRadians(vt.eulerAngles.z)) * l;
                        Debug.Log("x0 - "+vt.position.x+" x1 - "+x+" y0 - " + vt.position.y + " y1 - " + y);
                        vt.position = new Vector3((float) x, (float) y, 1);
//                            vt.position +=
//                                (vt.position/* + vt.eulerAngles*/) / 20f;
                        
                        
                        //vt.eulerAngles = new Vector3(0,0,vt.eulerAngles.z);
                        //vt.position = new Vector3(vt.position.x,vt.position.y,0);
//                        vt.position = new Vector3(vt.position.x,vt.position.y,0).normalized;
                        //vt.forward = new Vector3(vt.position.x,vt.position.y,1);
                        if (firstB == false){
                            // var _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//                            var qwe = new Vector2(_mousePosition.x,_mousePosition.y);
//                           //var qwe = new Vector2(vt.position.x+1, vt.position.y-1);
//                            vt.position = qwe;

//                            vt.position =
//                                (_mousePosition + vt.eulerAngles) / 20f;

//                            var l = 0.001 / Math.Cos(vt.eulerAngles.z);
//                            var x = vt.position.x + Math.Cos(ConvertToRadians(vt.eulerAngles.z)) * l;
//                            var y = vt.position.y + Math.Sin(ConvertToRadians(vt.eulerAngles.z)) * l;
//                            Debug.Log("x0 - "+vt.position.x+" x1 - "+x+" y0 - " + vt.position.y + " y1 - " + y);
//                            vt.position = new Vector3((float) x, (float) y, 1);
//                            firstB = true;
                        }
                        else{
                            
                        }
                        //vt.position = new Vector3(vt.position);
//                        v.Value.transform.position = Vector2.Lerp(v.Value.transform.position,
//                            v.Value.transform.eulerAngles, 1 / 300);

                        //v.Value.transform.position.z = v.Value.transform.eulerAngles.z
//                        Debug.Log(v.Value.transform.position);
                    }


                    //                    v.Value.AddForce(Vector2.left * bulletSpeed);
//                    v.Value.velocity = new Vector2(bulletSpeed, v.Value.velocity.y);
                    //v.Value.transform.position = Vector3.MoveTowards(v.Value.transform.position, Vector3.forward, bulletSpeed);
                    //v.Value.transform.position += (transform.position - v.Value.transform.position).normalized * 10 * Time.deltaTime;
//                    float angle = Mathf.MoveTowardsAngle(1f, 5f, bulletSpeed * Time.deltaTime);
//                    v.Value.transform.position = new Vector3(0, angle, 0);
                    //Debug.Log(v.Value.transfoVector2.left);
                }
            }
        }
    }
}