using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace main{
    public class Fire : MonoBehaviour{
        public int bulletType = 1;
        
        public List<Rigidbody2D> bb = new List<Rigidbody2D>();
        BulletCollection _currentBullet = null;
        public void CalculateStart(){
            
            foreach (var bullet in ImplementedBullet.ImplementedBulletDictionary){
                if (bullet.Key == bulletType){
                    _currentBullet = bullet.Value;
                }
            }
            if (_currentBullet != null){
//                bb = bb.Concat(_currentBullet.CreateClone(transform)).ToList();
                _currentBullet.CreateClone(transform);
            }
        }

        public void ClearAll(){
        }

//        void FixedUpdate(){
//            if (_currentBullet != null){
//                _currentBullet.Fly(bb);
//            }
//        }
    }
}