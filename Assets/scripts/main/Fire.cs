using System;
using System.Reflection;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour {
        private int _count = 0;
        private static Rigidbody2D _body;

        private void Start(){
            _body = gameObject.GetComponent<Rigidbody2D>();
        }

        public static void CalculateStart(){
            float asd = _body.transform.eulerAngles.z;
            Bullet.Create();
            Debug.Log(asd);
        }

        private void BulletTrace(){
            
        }
    }
}